using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public Dictionary<IngredientType, int> recipeIngredients;
    public PotionType createdPotionType;

    public bool MatchesRecipe(Dictionary<IngredientType, int> ingredients)
    {
        return ingredients.Equals(recipeIngredients);
    }
}
