using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base character class includes health component and abstract actions
/// </summary>
public abstract class CharacterBase : MonoBehaviour{

    #region Fields

    protected CharacterHealth characterHealth;

    #endregion

    #region Abstract Methods

    public abstract void Move(float moveX);

    public abstract void Flip(float moveX);

    public abstract void Atack();

    protected abstract void Jump(float jumpForce);

    public abstract void Hurt();

    protected abstract void Die();

    #endregion
}
