using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Lever leverHandle;
    private ParticleSystem pSystem;
    private float maxSize;
    private float minSize = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        maxSize = pSystem.main.startSize.constant;
        Debug.Log("Fire max size: " + maxSize);
    }

    // Update is called once per frame
    void Update()
    {
        var main = pSystem.main;
        main.startSize = GetFireSize();
    }

    private float GetFireSize()
    {
        return Mathf.Lerp(minSize, maxSize, GetLeverValue());
    }


    private float GetLeverValue()
    {
        if (leverHandle == null)
        {
            return 1;
        }
        return leverHandle.GetValue();
    }
}
