using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base behaviour class
/// </summary>
public abstract class BehaviourBase : MonoBehaviour
{
    [SerializeField] protected BaseBehaviour baseBehaviour;

    protected enum BaseBehaviour {

        Guardian,
        Patroller
    }

    protected abstract void DetectTarget();

    protected abstract void Guard();

    protected abstract void Patrol();

    protected abstract void Charge();

}
