using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public List<IngredientType> ingredientTypes;
    public List<int> ingredientCounts;
    public PotionType createdPotionType;

    public bool MatchesRecipe(Dictionary<IngredientType, int> ingredients)
    {
        if (ingredientTypes.Count != ingredients.Count)
        {
            return false;
        }
        for (int i = 0; i < ingredientTypes.Count; i++)
        {
            if (!ingredients.ContainsKey(ingredientTypes[i]) || ingredients[ingredientTypes[i]] != ingredientCounts[i])
            {
                return false;
            }
        }
        return true;
    }
}
