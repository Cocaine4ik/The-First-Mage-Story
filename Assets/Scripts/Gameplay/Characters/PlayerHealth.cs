using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    protected override void Awake()
    {
        base.Awake();
        changeResourceValue = EventName.HpChange;
        setResourceMaxValue = EventName.SetMaxHp;
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        EventManager.TriggerEvent(changeResourceValue, new EventArg(GetResourcePercent(damage)));
    }

    public override void RestoreHealth(int restorationValue)
    {
        EventManager.TriggerEvent(changeResourceValue, new EventArg(-GetResourcePercent(GetClearRestorationValue(restorationValue))));
        base.RestoreHealth(restorationValue);
    }

    public override void SetMaxHealth(int value)
    {
        base.SetMaxHealth(value);
        EventManager.TriggerEvent(setResourceMaxValue, new EventArg(GetResourcePercent(value)));
    }
}
