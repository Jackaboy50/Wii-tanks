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
        Instantiate(brownTank, new Vector3(100, 0, 100), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
