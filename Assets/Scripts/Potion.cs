using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public ParticleSystem bubbles;
    public ParticleSystem splash;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
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
        else if (potionType == PotionType.GREEN)
        {
            potionMaterial = "greenMat";
        }
        else if (potionType == PotionType.BLUE)
        {
            potionMaterial = "blueMat";
        }
        else if (potionType == PotionType.RED)
        {
            potionMaterial = "redMat";
        }
        //change potion material
        GetComponent<Renderer>().material = Resources.Load(potionMaterial, typeof(Material)) as Material;
        //change bubble material
        bubbles.GetComponent<Renderer>().material = Resources.Load(potionMaterial, typeof(Material)) as Material;
        //change splash material
        splash.GetComponent<Renderer>().material = Resources.Load(potionMaterial, typeof(Material)) as Material;
    }

    private void Reset()
    {
        splash.GetComponent<Renderer>().material = Resources.Load("default", typeof(Material)) as Material;
        bubbles.GetComponent<Renderer>().material = Resources.Load("default", typeof(Material)) as Material;
    }
}
