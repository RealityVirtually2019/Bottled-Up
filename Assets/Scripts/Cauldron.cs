using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

    private Dictionary<IngredientType, int> Ingredients = new Dictionary<IngredientType, int>();

    // Start is called before the first frame update
    void Start()
    {
       /*for (int i = 0; i < 3; i++)
        {
            AddPreparedIngredient(IngredientType.GLOWSHROOM);
            AddPreparedIngredient(IngredientType.SABERCLAW);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddIngredient(IngredientType i)
    {
        //poof animation here - invalid
    }

    void AddPreparedIngredient(IngredientType i)
    {
        Ingredients.TryGetValue(i, out int count);
        if (count == 0) Ingredients.Add(i, 1);
        else Ingredients[i]++;
    }

    void Brew()
    {

    }
    //algoritm to determine ingredients

}
