using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField] protected Transform atackPoint;

    [SerializeField] protected float speed = 5f;
    [SerializeField] protected int hp;

    protected abstract void Move(float moveX);

    protected abstract void Atack();

    protected abstract void Hurt();

    protected abstract void Die();
}
