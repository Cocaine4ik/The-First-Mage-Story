using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    // Change layer, make gameobject behaviour agreaaive or friendly

    public virtual void ChangeLayer()
    {
        var npcLayer = LayerMask.NameToLayer("NPC");
        var enemyLayer = LayerMask.NameToLayer("Enemy");

        if (gameObject.layer == npcLayer)
        {
            gameObject.layer = enemyLayer;
        }
        else if (gameObject.layer == enemyLayer)
        {
            gameObject.layer = npcLayer;
        }
    }
}
