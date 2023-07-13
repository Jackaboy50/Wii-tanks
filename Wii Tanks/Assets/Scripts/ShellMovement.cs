using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class ShellMovement : MonoBehaviour
{
    private float shellSpeed;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ricochetClip;
    [SerializeField] private AudioClip shellExplode;
    [SerializeField] private AudioClip shellFire;
    private int localShellRicochets;
    private float timeSinceLastRichochet;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = shellFire;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        transform.position += transform.forward * shellSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 16.5f, transform.position.z);
        transform.eulerAngles = new Vector3(0, currentRotation.y, 0);
    }

    public void SetShellType(string shellType)
    {
        switch (shellType)
        {
            case "Default":
                shellSpeed = 200;
                localShellRicochets = 1;
                break;
        }
    }

    IEnumerator Waiter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Map")
        {
            if(localShellRicochets > 0)
            {
                Ricochet(collision);
                timeSinceLastRichochet = Time.time;
            }
            else if(Time.time - timeSinceLastRichochet > 0.001)
            {
                audioSource.clip = shellExplode;
                audioSource.pitch = Random.Range(0.5f, 1f);
                audioSource.Play();
                gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                StartCoroutine(Waiter(0.3f));
            }
            localShellRicochets--;
        }
        else if (collision.gameObject.tag == "Tank")
        {
            KillTank(collision.gameObject);
        }
    }

    void Ricochet(Collision collision)
    {
        Vector3 ricochet = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
        transform.forward = ricochet;
        audioSource.clip = ricochetClip;
        audioSource.pitch = Random.Range(0.9f, 2f);
        audioSource.Play();
    }

    void KillTank(GameObject Tank)
    {
        Destroy(Tank);
    }
}
