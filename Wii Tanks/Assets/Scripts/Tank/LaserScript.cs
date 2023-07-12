using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private LineRenderer linerenderer;
    private float laserWidth = 2f;
    private float laserMaxLength = 1000f;
    [SerializeField] private GameObject firePoint;

    void Start()
    {
        Vector3[] laserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        linerenderer.SetPositions(laserPositions);
        linerenderer.startWidth = laserWidth;
        linerenderer.endWidth = laserWidth;
    }

    void Update()
    {
        ShootLaser(transform.position, transform.forward, laserMaxLength);
        linerenderer.enabled = true;
    }

    void ShootLaser(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        linerenderer.SetPosition(0, targetPosition);
        linerenderer.SetPosition(1, endPosition);
    }
}
