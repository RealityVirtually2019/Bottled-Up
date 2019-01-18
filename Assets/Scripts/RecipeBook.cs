using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public List<Recipe> recipes;

    private Recipe GetRecipe(Dictionary<IngredientType, int> testRecipe)
    {
        foreach (Recipe recipe in recipes)
        {
            if (recipe.matchesRecipe(testRecipe))
            {
                return recipe;
            }
        }
        return null;
    }

    public PotionType GetBrewingResult(Dictionary<IngredientType, int> testRecipe)
    {
        if (testRecipe.Keys.Count == 0)
        {
            return PotionType.NONE;
        }
        Recipe recipe = GetRecipe(testRecipe);
        if (recipe == null)
        {
            return PotionType.MISTAKE;
        }
        return recipe.createdPotionType;
    }
}
