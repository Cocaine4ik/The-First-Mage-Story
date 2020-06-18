using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell")]
public class Spell : ScriptableObject, ISpell
{
    [Header("Spell Data")]
    [SerializeField] private SpellName spellName;
    [SerializeField] private GameObject spellCastPrefab;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private EventName invokeEvent;
    [SerializeField] private SpellType spellType;
    [SerializeField] private DamageType damageType;
    [SerializeField] private EffectName spellEffect = EffectName.None;

    public SpellName SpellName => spellName;

    public GameObject SpellCastPrefab => throw new System.NotImplementedException();

    public GameObject ProjectilePrefab => throw new System.NotImplementedException();

    public EventName InvokeEvent => invokeEvent;

    public enum SpellType {
        Summon,
        Projectile,
        Target,
        Self
    }
}
