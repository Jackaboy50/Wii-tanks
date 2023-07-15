using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [Header("Scene Objects")]
    [SerializeField] private GameObject longOuterWall;
    [SerializeField] private GameObject longInnerFloor;

    [Header("Tanks")]
    [SerializeField] private GameObject playerTank;
    [SerializeField] private GameObject brownTank;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(longOuterWall);
        Instantiate(longInnerFloor);
        Instantiate(playerTank);
        Instantiate(brownTank, new Vector3(Random.Range(-360, 360), 0, Random.Range(-230, 260)), Quaternion.identity);
        //TankTest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TankTest()
    {
        for (int i = 0; i < 300; i++)
        {
            Instantiate(brownTank, new Vector3(Random.Range(-360, 360), 0, Random.Range(-230, 260)), Quaternion.identity);
        }
    }
}
