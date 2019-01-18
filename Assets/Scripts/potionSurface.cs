using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionSurface : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        ParticleSystem splash = GetComponentInChildren<ParticleSystem>();
        splash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("collide");
        ParticleSystem splash = GetComponentInChildren<ParticleSystem>();
        splash.Clear();
        splash.Play();
    }
}

