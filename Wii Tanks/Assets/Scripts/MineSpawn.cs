using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using UnityEngine;

public class MineSpawn : MonoBehaviour
{
    [SerializeField] private GameObject mine;

    private float mineDelay = 2f;
    private bool delayed = false;
    // Update is called once per frame
    void Update()
    {
        if (!delayed && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(mine, transform.position, Quaternion.identity);
            StartCoroutine(DelayMine(mineDelay));
        }
    }

    IEnumerator DelayMine(float seconds)
    {
        delayed = true;
        yield return new WaitForSeconds(seconds);
        delayed = false;
    }
}
