using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : Consumable
{
    public override string GetConsumableName()
    {
        return "Metal";
    }

    public override ConsumableType GetConsumableType()
    {
        return ConsumableType.METAL;
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
