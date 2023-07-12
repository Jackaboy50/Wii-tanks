using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private GameObject tankShell;
    int tankAmmo = 100;

    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tankAmmo > 0)
        {
            GameObject newShell = Instantiate(tankShell, transform.GetChild(0).transform.position, transform.rotation);
            newShell.GetComponent<ShellMovement>().SetShellType("Default");
            tankAmmo--;
        }
    }
}
