using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageData : MonoBehaviour{

    [SerializeField] protected int damage;
    [SerializeField] protected float atackRange;
    [SerializeField] protected DamageType damageType;
    [SerializeField] protected EffectName effect = EffectName.None;

    public float AtackRange => atackRange;

    public virtual int Damage { get => damage; set => damage = value; }
    public DamageType  DamageType { get => damageType; set => damageType = value; }
    public EffectName Effect { get => effect; set => effect = value; }
}
