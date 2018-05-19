using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compost : Consumable
{
    public override string GetConsumableName()
    {
        return "Compost";
    }

    public override ConsumableType GetConsumableType()
    {
        return ConsumableType.COMPOST;
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
