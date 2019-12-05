using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTrigger : MonoBehaviour {

    [SerializeField] protected int damage;

    public int Damage {
        get { return damage; }
    }
}
