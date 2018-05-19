using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuclear : Consumable
{
    public override string GetConsumableName()
    {
        return "Nuclear";
    }

    public override ConsumableType GetConsumableType()
    {
        return ConsumableType.NUCLEAR;
    }

    public override int GetPremiumCost()
    {
        return 0;
    }

    public override int GetPrice()
    {
        return 0;
    }
}
