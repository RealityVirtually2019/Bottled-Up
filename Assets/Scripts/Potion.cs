using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public ParticleSystem bubbles;
    // Start is called before the first frame update
    void Start()
    {
        //ChangeColor(PotionType.NONE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(PotionType potionType)
    {
        var potionMaterial = "";

        if (potionType == PotionType.NONE)
        {
            potionMaterial = "mistake";
        }
        else if (potionType == PotionType.HEALTH)
        {
            potionMaterial = "health";
        }
        //change potion material
        GetComponent<Renderer>().material = Resources.Load(potionMaterial, typeof(Material)) as Material;
        //change bubble material
        bubbles.GetComponent<Renderer>().material = Resources.Load(potionMaterial, typeof(Material)) as Material;
    }
}
