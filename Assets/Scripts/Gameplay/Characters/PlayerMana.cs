using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : CharacterMana
{
    protected override void Awake()
    {
        base.Awake();
        changeResourceValue = EventName.ManaChange;
        setResourceMaxValue = EventName.SetMaxMana;
    }
    public override void BurnMana(int burnedMana)
    {
        base.BurnMana(burnedMana);

        EventManager.TriggerEvent(changeResourceValue, new EventArg(GetResourcePercent(burnedMana)));
    }

    public override void RestoreMana(int restorationValue)
    {
        base.RestoreMana(restorationValue);
        EventManager.TriggerEvent(changeResourceValue, new EventArg(-GetResourcePercent(GetClearRestorationValue(restorationValue))));
    }

    public override void SetMaxMana(int value)
    {
        base.SetMaxMana(value);
        EventManager.TriggerEvent(setResourceMaxValue, new EventArg(GetResourcePercent(value)));
    }
}
