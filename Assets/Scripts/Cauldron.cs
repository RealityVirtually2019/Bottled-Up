using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public int minStirSpeed = 2;
    public int clampMaxStirSpeed = 50;
    public float stirringProgressMultiplier = 1;
    private float stirringProgress = 0;
    private Dictionary<IngredientType, int> Ingredients = new Dictionary<IngredientType, int>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stirringProgress >= 100)
        {
            Brew();
            stirringProgress = 0;
        }
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

    private void OnTriggerStay(Collider otherCollider)
    {
        Tool collidedTool = otherCollider.GetComponent<Tool>();
        if (collidedTool != null && collidedTool.toolType == ToolType.STIRRER)
        {
            float toolSpeed = collidedTool.GetSpeed();
            if (toolSpeed >= minStirSpeed)
            {
                stirringProgress += Mathf.Clamp(toolSpeed, 0, clampMaxStirSpeed) * stirringProgressMultiplier * Time.deltaTime;
                if (Random.value < 0.2f)
                {
                    Debug.Log("Stirring progress: " + stirringProgress);
                }
            }
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
