using UnityEngine;
public interface ISpell
{
    SpellName SpellName { get; }
    GameObject SpellCastPrefab { get; }
    GameObject ProjectilePrefab { get; }
    EventName InvokeEvent { get;  }
    SpellType SpellType { get;  }
    int SpellDamage { get; }
    DamageType DamageType { get; }
    EffectName SpellEffect { get; }
    int ManaCost { get; }
    float Cooldown { get; }
}
