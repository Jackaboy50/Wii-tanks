using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    [SerializeField] private GameObject Cannon;
    [SerializeField] private GameObject tankBase;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] tankTrackClips = new AudioClip[4];
    private int trackIndex = 0;
    bool waiting = false;

    private float movementSpeed = 50;
    private float rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if(vertical != 0)
        {
            transform.position += transform.forward * vertical * movementSpeed * Time.deltaTime;
            if (!audioSource.isPlaying)
            {
                RandomTrackSound();
            }
        }

        transform.Rotate(0, (Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime), 0);
    }

    void RandomTrackSound()
    {
        int index = Random.Range(0, 3);
        while(audioSource.clip == tankTrackClips[index])
        {
            index = Random.Range(0, 3);
            
        }
        audioSource.clip = tankTrackClips[index];
        audioSource.PlayDelayed(0.01f);
    }
}
