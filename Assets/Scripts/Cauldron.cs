using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

    private Dictionary<IngredientType, int> Ingredients = new Dictionary<IngredientType, int>();

    // Start is called before the first frame update
    void Start()
    {
        AddPreparedIngredient(IngredientType.SABERCLAW);
        AddPreparedIngredient(IngredientType.GLOWSHROOM);
        AddPreparedIngredient(IngredientType.SABERCLAW);
        Brew();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        PreparedIngredient collidedIngredient = otherCollider.GetComponent<PreparedIngredient>();
        if (collidedIngredient != null)
        {
            AddPreparedIngredient(collidedIngredient.ingredientType);
            collidedIngredient.OnCauldronEnter();
        }
    }

    void AddPreparedIngredient(IngredientType i)
    {
        Ingredients.TryGetValue(i, out int count);
        if (count == 0) Ingredients.Add(i, 1);
        else Ingredients[i]++;
    }

    void Brew()
    {
        PotionType type = getType();
        Debug.Log("Potion type is " + type);
    }

    PotionType getType()
    {
        if (Ingredients[IngredientType.SABERCLAW] == 2 && Ingredients[IngredientType.GLOWSHROOM] == 1)
            return PotionType.HEALTH;
        else if (Ingredients[IngredientType.GLOWSHROOM] == 3)
            return PotionType.GLOW;
        else return PotionType.MISTAKE;
    }
}
