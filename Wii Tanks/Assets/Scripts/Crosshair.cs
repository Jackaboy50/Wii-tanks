using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Crosshair : MonoBehaviour
{
    Camera mainCamera;
    int layerNumber = 6;
    int groundMask;
    
    void Awake()
    {
        UnityEngine.Cursor.visible = false;
        mainCamera = Camera.main;
        groundMask = 1 << layerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GetMousePosition();
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundMask))
        {
            Vector3 position = new Vector3(hitInfo.point.x, 5, hitInfo.point.z);
            return position;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
