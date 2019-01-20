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
        if (cauldron != null && cauldron.GetPotionType() != PotionType.NONE)
        {
            type = cauldron.GetPotionType();
            Debug.Log("This bottle is now of type " + type);
            switch (type)
            {
                case PotionType.GREEN:
                    ChangeColor("greenMat");
                    break;
                case PotionType.BLUE:
                    ChangeColor("blueMat");
                    break;
                case PotionType.RED:
                    ChangeColor("redMat");
                    break;
                case PotionType.MISTAKE:
                    ChangeColor("mistake");
                    break;
                default:
                    ChangeColor("default");
                    break;
            }
        }
    }

    void ChangeColor(string typeName)
    {
        gameObject.transform.GetChild(1).GetComponent<Renderer>().material = Resources.Load(typeName, typeof(Material)) as Material;
    }

    private void Reset()
    {
        type = PotionType.NONE;
        //TODO: add reset of color, empty bottle, etc
    }
}
