using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : CharacterResource
{
    protected Resistances resistances;

    protected void Start()
    {
        resistances = GetComponent<Resistances>();
    }
    public virtual void TakeDamage(int damage, DamageType damageType)
    {
        // if current health > damage we dont play hurt animation and play only death animation
        if(currentValue > damage) {
            GetComponentInParent<Character>().Hurt();
        }
        Debug.Log(damage);
        BurnResource(CalculatePoorDamage(damage, damageType));
    }

    public virtual void RestoreHealth(int restorationValue)
    {
        RestoreResource(restorationValue);
    }

    public virtual void SetMaxHealth(int value)
    {
        SetResourceMaxValue(value);
    }

    protected int CalculatePoorDamage(int damage, DamageType damageType)
    {
        switch(damageType)
        {
            case DamageType.Divine: return damage - resistances.DivineResitance;
            case DamageType.Fire: return damage - resistances.FireResistance;
            case DamageType.Ice: return damage - resistances.FireResistance;
            case DamageType.Nature: return damage - resistances.NatureResistance;
            case DamageType.Physical: return damage - resistances.PhysicalResistance;
            case DamageType.Veil: return damage - resistances.VeilResistannce;
            case DamageType.None: return damage;
            default: return damage;
        }
    }
}
