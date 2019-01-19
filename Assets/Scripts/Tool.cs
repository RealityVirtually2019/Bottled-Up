using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public ToolType toolType;
    private Vector3 priorPos;
    private Vector3 currentPos;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        priorPos = transform.position;
        currentPos = transform.position;
        velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        velocity = (currentPos - priorPos) / Time.deltaTime;
        priorPos = transform.position;
    }

    public float GetSpeed()
    {
        return velocity.magnitude;
    }


}
