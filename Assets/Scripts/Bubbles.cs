using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public Lever leverHandle;
    private ParticleSystem pSystem;
    private float maxAmount;
    private float minAmount = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        maxAmount = pSystem.emission.rateOverTime.constant;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = pSystem.emission;
        emission.rateOverTime = GetBubblesSize();
    }

    private float GetBubblesSize()
    {
        return Mathf.Lerp(minAmount, maxAmount, GetLeverValue());
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
