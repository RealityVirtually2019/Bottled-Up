using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public PotionType type; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        Cauldron cauldron = otherCollider.GetComponent<Cauldron>();
        if (cauldron != null && cauldron.finalType != PotionType.NONE)
        {
            type = cauldron.finalType;
            Debug.Log("This bottle is now of type " + type);
        }
    }

    private void Reset()
    {
        type = PotionType.NONE;
        //TODO: add reset of color, empty bottle, etc
    }
}
