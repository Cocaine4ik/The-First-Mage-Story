using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMana : CharacterResource
{

    public virtual void BurnMana(int burnedMana)
    {
        BurnResource(burnedMana);
    }

    public virtual void RestoreMana(int restorationValue)
    {
        RestoreResource(restorationValue);
    }
    public virtual void SetMaxMana(int value)
    {
        SetResourceMaxValue(value);
    }
}
