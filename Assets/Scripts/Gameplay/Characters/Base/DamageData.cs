﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageData : MonoBehaviour {

    [SerializeField] protected int damage;
    [SerializeField] public float atackRange;

    public int Damage {
        get {
            if (gameObject.GetComponentInChildren<Player>() != null)
                return damage + Attributes.Instance.Knowledge;
            else return damage;
        }
    }
    public float AtackRange => atackRange;

}