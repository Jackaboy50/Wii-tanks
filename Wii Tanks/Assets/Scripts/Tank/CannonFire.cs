using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private GameObject tankShell;

    private float reloadTime;
    private int tankAmmo = 5;
    private bool waiting = false;
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
        else if(tankAmmo == 0 && waiting == false)
        {
            StartCoroutine(Reload(3));
        }
    }
    IEnumerator Reload(int seconds)
    {
        waiting = true;
        yield return new WaitForSeconds(seconds);
        tankAmmo = 5;
        waiting = false;
    }
}
