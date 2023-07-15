using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDeath : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject deathMark;

    [SerializeField] private GameObject cannon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KillTank(float seconds)
    {
        audioSource.clip = deathSound;
        audioSource.Play();
        Instantiate(deathMark, new Vector3(transform.parent.position.x, 1f, transform.parent.position.z), new Quaternion(0.7071f, 0, 0, 0.7071f));
        gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        cannon.GetComponent<brownCannon>().enabled = false;
        yield return new WaitForSeconds(seconds);
        Destroy(transform.parent.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collison");
        if(collision.gameObject.tag == "Shell")
        {
            StartCoroutine(KillTank(0.7f));
        }
    }
}
