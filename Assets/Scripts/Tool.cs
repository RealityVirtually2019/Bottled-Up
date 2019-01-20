using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public ToolType toolType;
    private Vector3 priorPos;
    private Vector3 currentPos;
    private Vector3 velocity;
    private bool isActiveTool = true;
    private float deactivatedTime = 0;
    private float cooldownTime = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        priorPos = transform.position;
        currentPos = transform.position;
        velocity = new Vector3(0, 0, 0);
        deactivatedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        velocity = (currentPos - priorPos) / Time.deltaTime;
        priorPos = transform.position;
        if (!isActiveTool && Time.time - deactivatedTime > cooldownTime)
        {
            isActiveTool = true;
        }
    }

    public float GetSpeed()
    {
        return velocity.magnitude;
    }

    public void DeactivateTool() {
        isActiveTool = false;
        deactivatedTime = Time.time;
    }

    public bool IsActiveTool() {
        return isActiveTool;
    }


}
