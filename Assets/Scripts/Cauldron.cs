using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public RecipeBook recipeBook;
    private int minStirSpeed = 2;
    private int clampMaxStirSpeed = 100;
    private float stirringProgressMultiplier = 1;
    private float stirringProgress = 0;
    private Dictionary<IngredientType, int> ingredients = new Dictionary<IngredientType, int>();
    private PotionType potionType = PotionType.NONE;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stirringProgress >= 2)
        {
            stirringProgress = 0;
            Brew();
        }
    }

    private void OnTriggerEnter(Collider otherCollider) //make more broad for other objects
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
        Debug.Log("adding " + ingredientType);
    }

    void Brew()
    {
        potionType = recipeBook.GetBrewingResult(ingredients);
        ingredients.Clear();
        Debug.Log("Potion type is " + potionType);
        gameObject.GetComponent<Potion>().ChangeColor(potionType);

    }

    public PotionType GetPotionType()
    {
        return potionType;
    }

    public void Reset()
    {
        Debug.Log("Resetting cauldron.");
        potionType = PotionType.NONE;
        ingredients.Clear();
        Debug.Log("Potion component: " + gameObject.GetComponent<Potion>());
        gameObject.GetComponent<Potion>().Reset();
    }
}
