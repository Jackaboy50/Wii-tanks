using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    Camera mainCamera;
    Vector3 position;
    bool success;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        success = GetMousePosition();
        if (success == true)
        {
            Vector3 currentRotation = transform.eulerAngles;
            Vector3 direction = position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
            transform.eulerAngles = new Vector3(currentRotation.x, transform.eulerAngles.y, currentRotation.z);
        }
    }

    private bool GetMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            position = hitInfo.point;
            return true;
        }
        else
        {
            position = Vector3.zero;
            return false;
        }
    }
}
