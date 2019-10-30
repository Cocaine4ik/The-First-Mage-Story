using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTrigger : MonoBehaviour {

    [SerializeField] protected GameObject owner;
    [SerializeField] protected int damage;

    public GameObject Owner {
        get { return owner; }
    }

    public int Damage {
        get { return damage; }
    }
}
