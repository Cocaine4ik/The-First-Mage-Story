using UnityEngine;
public interface ISpell
{
    SpellName SpellName { get; }
    GameObject ProjectilePrefab { get; }
    SpellType SpellType { get;  }
    int SpellDamage { get; }
    DamageType DamageType { get; }
    EffectName SpellEffect { get; }
    int ManaCost { get; }
    float Cooldown { get; }
}
