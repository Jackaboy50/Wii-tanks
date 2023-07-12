using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class ShellMovement : MonoBehaviour
{
    [SerializeField] private float shellSpeed;
    private int localShellRicochets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
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
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Map")
        {
            if(localShellRicochets > 0)
            {
                Ricochet(collision);
            }
            else
            {
                Destroy(this.gameObject);
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
    }

    void KillTank(GameObject Tank)
    {
        Destroy(Tank);
    }
}
