using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class brownCannon : MonoBehaviour
{
    private float previousShotTime;

    bool waiting = false;
    private Quaternion lookRotation;
    private Quaternion[] rotationPoints = new Quaternion[] 
    { 
        Quaternion.Euler(0, 0, 0), 
        Quaternion.Euler(45, 0, 0),
        Quaternion.Euler(90, 0, 0),
        Quaternion.Euler(135, 0, 0),
        Quaternion.Euler(180, 0, 0),
        Quaternion.Euler(225, 0, 0),
        Quaternion.Euler(270, 0, 0),
        Quaternion.Euler(315, 0, 0),
        Quaternion.Euler(360, 0, 0),
    };

    [SerializeField] private GameObject tankShell;
    // Start is called before the first frame update
    void Start()
    {
        lookRotation = rotationPoints[Random.Range(1, 9)];
    }

    // Update is called once per frame
    void Update()
    {
        RandomCannonMovement();
        CheckForPlayer(transform.position, transform.forward);
    }

    void RandomCannonMovement()
    {
        Vector3 currentRotation = transform.eulerAngles;
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 0.08f);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(currentRotation.x, transform.eulerAngles.y, currentRotation.z);
        if (!waiting)
        {
            StartCoroutine(ChangeAngles(3));
        }
    }

    IEnumerator ChangeAngles(int seconds)
    {
        waiting = true;
        yield return new WaitForSeconds(seconds);
        int index = Random.Range(0, 9);
        while(lookRotation == rotationPoints[index])
        {
            index = Random.Range(0, 9);
        }
        lookRotation = rotationPoints[index];
        waiting = false;
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
