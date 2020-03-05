﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackWeapon : MonoBehaviour {

    [SerializeField] protected int damage;
    [SerializeField] public float atackRange;

    public int Damage => damage;
    public float AtackRange => atackRange;

}