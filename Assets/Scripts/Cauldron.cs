using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public int minStirSpeed = 2;
    public int clampMaxStirSpeed = 50;
    public float stirringProgressMultiplier = 1;
    private float stirringProgress = 0;
    private Dictionary<IngredientType, int> ingredients = new Dictionary<IngredientType, int>();
    public PotionType potionType = PotionType.NONE;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (stirringProgress >= 100)
        {
            stirringProgress = 0;
            Brew();
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

    void AddPreparedIngredient(IngredientType ingredientType)
    {
        ingredients.TryGetValue(ingredientType, out int count);
        if (count == 0) ingredients.Add(ingredientType, 1);
        else ingredients[ingredientType]++;
    }

    void Brew()
    {
        potionType = GetPotionType();
        Debug.Log("Potion type is " + potionType);
    }

    PotionType GetPotionType()
    {
        if (ingredients.ContainsKey(IngredientType.SABERCLAW) && ingredients.ContainsKey(IngredientType.GLOWSHROOM) && 
                ingredients[IngredientType.SABERCLAW] == 2 && ingredients[IngredientType.GLOWSHROOM] == 1)
            return PotionType.HEALTH;
        else if (ingredients.ContainsKey(IngredientType.GLOWSHROOM) && ingredients[IngredientType.GLOWSHROOM] == 3)
            return PotionType.GLOW;
        else return PotionType.MISTAKE;
    }

    private void Reset()
    {
        ingredients.Clear();
    }
}
