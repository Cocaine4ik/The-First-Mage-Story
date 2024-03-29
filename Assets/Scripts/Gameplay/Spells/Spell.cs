﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell")]
public class Spell : ScriptableObject, ISpell
{
    [Header("Spell Data")]
    [SerializeField] private SpellName spellName;
    [SerializeField] private Sprite spellIcon;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private SpellType spellType;
    [SerializeField] private int spellDamage;
    [SerializeField] private DamageType damageType;
    [SerializeField] private EffectName spellEffect = EffectName.None;
    [SerializeField] private int manaCost;
    [SerializeField] private float cooldown;

    public SpellName SpellName => spellName;
    public Sprite SpellIcon => spellIcon;
    public GameObject ProjectilePrefab => projectilePrefab;
    public SpellType SpellType => spellType;
    public EffectName SpellEffect => spellEffect;
    public int SpellDamage => spellDamage;
    public DamageType DamageType => damageType;
    public int ManaCost => manaCost;
    public float Cooldown => cooldown;

}
