using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGrabber : MonoBehaviour
{
    // NOTE: This is just a class used for testing

    public Lever leverHandle;

    // Start is called before the first frame update
    void Start()
    {
        leverHandle.GrabBy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
