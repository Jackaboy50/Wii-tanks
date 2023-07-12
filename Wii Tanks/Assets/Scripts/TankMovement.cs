using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    [SerializeField] private GameObject Cannon;
    [SerializeField] private GameObject tankBase;

    private float movementSpeed = 50;
    private float rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if(vertical != 0)
        {
            transform.position += transform.forward * vertical * movementSpeed * Time.deltaTime;
        }

        transform.Rotate(0, (Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime), 0);
    }
}
