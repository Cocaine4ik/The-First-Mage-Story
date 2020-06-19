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
    [SerializeField] private int spellDamage;
    [SerializeField] private DamageType damageType;
    [SerializeField] private EffectName spellEffect = EffectName.None;
    [SerializeField] private int manaCost;
    [SerializeField] private float cooldown;

    public SpellName SpellName => spellName;
    public GameObject SpellCastPrefab => spellCastPrefab;
    public GameObject ProjectilePrefab => projectilePrefab;
    public EventName InvokeEvent => invokeEvent;
    public SpellType SpellType => spellType;
    public EffectName SpellEffect => spellEffect;
    public int SpellDamage => spellDamage;
    public DamageType DamageType => damageType;
    public int ManaCost => manaCost;
    public float Cooldown => cooldown;

}
