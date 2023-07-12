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
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(longOuterWall);
        Instantiate(longInnerFloor);
        Instantiate(playerTank);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
