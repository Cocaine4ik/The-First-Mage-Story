using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : CharacterResource
{
    public virtual void TakeDamage(int damage)
    {
        // if current health > damage we dont play hurt animation and play only death animation
        if(currentValue > damage) {
            GetComponentInParent<Character>().Hurt();
        }
        BurnResource(damage);
    }

    public virtual void RestoreHealth(int restorationValue)
    {
        RestoreResource(restorationValue);
    }

    public virtual void SetMaxHealth(int value)
    {
        SetResourceMaxValue(value);
    }
}
