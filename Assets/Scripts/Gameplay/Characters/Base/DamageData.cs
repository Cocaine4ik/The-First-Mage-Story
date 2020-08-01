using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageData : MonoBehaviour{

    [SerializeField] protected int damage;
    [SerializeField] protected float atackRange;
    [SerializeField] protected DamageType damageType;
    [SerializeField] protected EffectName effect = EffectName.None;

    public float AtackRange => atackRange;

    public int Damage {
        get {
            if (gameObject.GetComponentInChildren<Player>() != null)
                return damage + Attributes.Instance.Knowledge;
            else return damage;
        }
        set { damage = value; }
    }

    public DamageType  DamageType {
        get { return damageType; }
        set { damageType = value; }
    }
    public EffectName Effect {
        get { return effect; }
        set { effect = value; }
    }
}
