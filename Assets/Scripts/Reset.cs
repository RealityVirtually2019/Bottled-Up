using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Cauldron cauldron;
    public Potion potion;
    public GameObject ingredients;
    public GameObject bottles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ResetEverything();
        }
    }

    void ResetEverything()
    {
        Destroy(ingredients);
        GameObject newIngredients = Resources.Load("ingredients", typeof(GameObject)) as GameObject;
        ingredients = Instantiate(newIngredients, newIngredients.transform.position, newIngredients.transform.rotation);

        Destroy(bottles);
        GameObject newBottles = Resources.Load("Bottles", typeof(GameObject)) as GameObject;
        bottles = Instantiate(newBottles, newBottles.transform.position, newBottles.transform.rotation);

        potion.Reset();
        cauldron.Reset();
    }
}
