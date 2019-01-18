using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // NOTE: This class just for testing purposes
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
