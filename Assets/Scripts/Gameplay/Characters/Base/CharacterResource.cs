using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterResource : MonoBehaviour
{
    [SerializeField] protected int currentValue;
    [SerializeField] protected int maxValue;

    protected EventName changeResourceValue;
    protected EventName setResourceMaxValue;

    public int CurrentValue => currentValue;
    public int MaxValue => maxValue;

    protected virtual void Awake()
    {
        // initialize current resource value
        currentValue = maxValue;
    }

    protected void BurnResource(int burnedValue)
    {
        currentValue -= burnedValue;
    }

    protected void RestoreResource(int restorationValue)
    {
        currentValue += GetClearRestorationValue(restorationValue);
    }

    protected int GetClearRestorationValue(int restorationValue)
    {
        var clearRestorationValue = restorationValue;
        var maxCurrentDif = maxValue - currentValue;

        if (restorationValue > maxCurrentDif) clearRestorationValue = maxCurrentDif;

        return clearRestorationValue;
    }

    protected float GetResourcePercent(int value)
    {
        var resourcePercent = (float)value / maxValue;
        return resourcePercent;
    }
    protected void SetResourceMaxValue(int value)
    {
        maxValue = value;
    }
}
