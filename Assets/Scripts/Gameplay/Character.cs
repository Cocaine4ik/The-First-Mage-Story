using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField] protected Transform atackPoint;
    [SerializeField] protected GameObject corpse;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected int lvl;
    [SerializeField] protected int exp;
    [SerializeField] protected int hp;

    protected abstract void Move(float moveX);

    protected abstract void Flip(float moveX);

    protected abstract void Atack();

    protected abstract void Jump(float jumpForce);

    protected abstract void TakeDamage(int damage);

    protected abstract void Hurt();

    protected abstract void Die();
}
