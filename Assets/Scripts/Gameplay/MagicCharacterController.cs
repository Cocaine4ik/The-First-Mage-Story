using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCharacterController : CharacterController2D {

    #region Fields

    [SerializeField] protected int mana;
    [SerializeField] protected GameObject projectilePrefab;
    protected Vector2 teleportPosition;

    protected bool isTeleportedIn = false;
    protected bool isTeleportedOut = false;

    #endregion

    #region Methods

    protected void Teleport() {

        teleportPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isTeleportedIn = true;
        animator.SetBool("IsTeleportedIn", isTeleportedIn);

    }

    protected virtual void TeleportToPoint(Vector2 point) {

        gameObject.transform.position = point;

    }

    protected override void AddAnimatorParametes() {
        base.AddAnimatorParametes();
        animatorController.AddParameter("IsTeleportedIn", AnimatorControllerParameterType.Bool);
        animatorController.AddParameter("IsTeleportedOut", AnimatorControllerParameterType.Bool);
    }
    #endregion

    #region Animation Events

    protected void OnTeleport() {
        isTeleportedIn = false;
        animator.SetBool("IsTeleportedIn", isTeleportedIn);
        TeleportToPoint(teleportPosition);
        isTeleportedOut = true;
        animator.SetBool("IsTeleportedOut", isTeleportedOut);
    }
    protected void OutTeleport() {
        isTeleportedOut = false;
        animator.SetBool("IsTeleportedOut", isTeleportedOut);
    }

    protected void RangeAtack() {

            Instantiate(projectilePrefab, atackPoint.position, atackPoint.rotation);
    }

    #endregion
}
