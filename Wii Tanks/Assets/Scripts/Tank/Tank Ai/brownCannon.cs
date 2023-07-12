using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class brownCannon : MonoBehaviour
{
    private float previousShotTime;

    private float rotationSpeed = 0.5f;
    private float rotationRange = 0.3f;
    private Quaternion lookRotation;
    private Quaternion minRotation;
    private Quaternion maxRotation;

    [SerializeField] private GameObject tankShell;
    // Start is called before the first frame update
    void Start()
    {
        maxRotation = Quaternion.Euler(180, 0, 0);
        minRotation = Quaternion.Euler(0, 0, 0);
        lookRotation = maxRotation;
    }

    // Update is called once per frame
    void Update()
    {
        CannonMovement();
        CheckForPlayer(transform.position, transform.forward);
    }

    void CannonMovement()
    {
        Vector3 currentRotation = transform.eulerAngles;
        if (transform.rotation.x >= 1 - rotationRange - 0.05)
        {
            lookRotation = minRotation;
        }
        else if (transform.rotation.x <= 0 + rotationRange)
        {
            lookRotation = maxRotation;
        }
        Quaternion rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(currentRotation.x, transform.eulerAngles.y, currentRotation.z);
    }

    void CheckForPlayer(Vector3 targetPosition, Vector3 direction)
    {
        Ray ray = new Ray(targetPosition, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if(hitInfo.transform.tag == "Player")
            {
                CannonFire();
            }
        }
    }
    void CannonFire()
    {
        if(Time.time - previousShotTime > 2)
        {
            GameObject newShell = Instantiate(tankShell, transform.GetChild(0).transform.position, transform.rotation);
            newShell.GetComponent<ShellMovement>().SetShellType("Default");
            previousShotTime = Time.time;
        }
    }
}
