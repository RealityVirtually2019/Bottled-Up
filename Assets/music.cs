using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource fxSound; 
    public AudioClip backMusic; 

    void Start()
    {
        fxSound = GetComponent<AudioSource>();
        fxSound.Play();
    }

}

