using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private float maxDist = 1.34f;
    private Transform targetTransform = null;
    private float initialY;
    private float initialZ;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.localPosition.y;
        initialZ = transform.localPosition.z;
        transform.localPosition = new Vector3(-maxDist, initialY, initialZ);
    }

    // Update is called once per frame
    void Update()
    {
        FollowTargetObject();
        if (Random.value < 0.05f)
        {
            Debug.Log("Lever value: " + GetValue());
        }
    }

    void FollowTargetObject()
    {
        float targetX = transform.parent.InverseTransformPoint(targetTransform.position).x;
        transform.localPosition = new Vector3(Mathf.Clamp(targetX, -maxDist, maxDist), initialY, initialZ);
    }

    public void GrabBy(GameObject followee)
    {
        targetTransform = followee.transform;
    }

    public void Release()
    {
        targetTransform = null;
    }

    // From 0 to 1
    public float GetValue() {
        return (transform.localPosition.x + maxDist) / (2 * maxDist);
    }
}
