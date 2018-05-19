using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANALYTICS
using UnityEngine.Analytics;
#endif

/// <summary>
/// The RecipeManager handles the currently being built recipe, and returns the result of that recipe when it finishes.
/// I heedlessly copied it from the trackmanager
/// </summary>
public class RecipeManager
{
	static public RecipeManager instance { get { return s_Instance; } }
	static protected RecipeManager s_Instance;

    protected Dictionary<string, int> ingredientQueue = new Dictionary<string, int>();

    public void AddIngredient(Consumable newIngredient)
    {
        string ingType = newIngredient.GetConsumableName();
        if (!ingredientQueue.ContainsKey(ingType))
        {
            ingredientQueue.Add(ingType, 1);
        }
        else
        {
            int currentQuantity = ingredientQueue[ingType];
            ingredientQueue[ingType] = currentQuantity + 1;
        }
    }

    public int GetIngredientQuantity(string ingredient)
    {
        return ingredientQueue.ContainsKey(ingredient) ? ingredientQueue[ingredient] : 0;
    }

    void OnGUI()
    {

        GUI.Label(new Rect(0, 0, 100, 100), "butt");
        /// GUI.Label(new Rect(10, 40, textureToDisplay.width, textureToDisplay.height), textureToDisplay);
    }


}