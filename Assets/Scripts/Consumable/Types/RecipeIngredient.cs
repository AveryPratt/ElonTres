using UnityEngine;
using System;

public class RecipeIngredient : Consumable
{
    public override string GetConsumableName()
    {
        return IngredientName;
    }

    public override ConsumableType GetConsumableType()
    {
        return ConsumableType.SCIENTIST;
    }

    public override int GetPrice()
    {
        return 750;
    }

	public override int GetPremiumCost()
	{
		return 0;
	}

	public override void Started(CharacterInputController c)
    {
        base.Started(c);

        ///m_SinceStart = 0;

        ///c.trackManager.modifyMultiply += MultiplyModify;
        c.recipeManager.AddIngredient(this);
    }

    protected int MultiplyModify(int multi)
    {
        return multi * 2;
    }
}
