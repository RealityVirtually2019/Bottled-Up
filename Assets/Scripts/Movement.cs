using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // NOTE: This class just for testing purposes
    public Vector3 velocity;
    public float flipInterval = 1;
    public bool flip = false;
    private float lastFlipTime;

    // Start is called before the first frame update
    void Start()
    {
        lastFlipTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (flip)
        {
            if (Time.time - lastFlipTime > flipInterval)
            {
                velocity *= -1;
                lastFlipTime = Time.time;
            }
        }
        transform.position += velocity * Time.deltaTime;
    }
}
