using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material yellowMat;
    [SerializeField] private Material redMat;
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip minePlant;
    [SerializeField] private AudioClip mineExplode;

    private string[] colliderTags = new string[] { "Shell", "Tank", "Player" };

    private bool yellow = false;
    private bool active = false;
    private bool armed = false;

    private float armTime = 1f;
    private float dormantTime = 9f;
    private float explodeTime = 2.5f;
    
    void Start()
    {
        audioSource.clip = minePlant;
        audioSource.Play();
        StartCoroutine(Waiter());
    }
    void Update()
    {
        if(active)
        {
            MaterialSwap();
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(armTime);
        armed = true;
        yield return new WaitForSeconds(dormantTime);
        active = true;
        yield return new WaitForSeconds(explodeTime);
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        audioSource.clip = mineExplode;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }

    void MaterialSwap()
    {
        if (!yellow)
        {
            GetComponent<Renderer>().material = yellowMat;
        }
        else
        {
            GetComponent<Renderer>().material = redMat;
        }
        yellow = !yellow;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (colliderTags.Contains(collision.gameObject.tag) && armed)
        {
            StartCoroutine(Explode());
        }
    }
}
