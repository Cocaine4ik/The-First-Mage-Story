using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCharacterController : CharacterController2D {

    #region Fields

    [SerializeField] protected int mana;
    [SerializeField] protected int currentMana;
    [SerializeField] protected const int manaPerTeleport = 5;
    [SerializeField] protected GameObject projectilePrefab;
    protected Vector2 teleportPosition;

    protected bool isTeleportedIn = false;
    protected bool isTeleportedOut = false;

    #endregion

    #region Methods

    protected override void Start()
    {
        base.Start();
        currentMana = mana;
    }
    protected void Teleport() {

        teleportPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isTeleportedIn = true;
        animator.SetBool("IsTeleportedIn", isTeleportedIn);

    }

    protected virtual void TeleportToPoint(Vector2 point) {

        gameObject.transform.position = point;

    }
    // calculate hoew much mana will burned for teleport to point
    private int ManaBurnedForTeleport(Vector2 teleportPosition) {

        // calculate X teleport distance
        float teleportDistanceX = Mathf.Abs(teleportPosition.x - gameObject.transform.position.x);
        // calculate Y teleport distance
        float teleportDistanceY = Mathf.Abs(teleportPosition.y - gameObject.transform.position.y);
        // calculate all telport distance
        float teleportDistance = teleportDistanceX + teleportDistanceY;

        return manaPerTeleport * (int)teleportDistance;
    }
    #endregion

    #region Animation Events

    protected virtual void OnTeleport() {

        isTeleportedIn = false;
        animator.SetBool("IsTeleportedIn", isTeleportedIn);

        int manaBurnedForTeleport = ManaBurnedForTeleport(teleportPosition);

        if (currentMana >= manaBurnedForTeleport) {

            currentMana -= manaBurnedForTeleport;

            TeleportToPoint(teleportPosition);
            isTeleportedOut = true;
            animator.SetBool("IsTeleportedOut", isTeleportedOut);

            if(gameObject.GetComponent<Player>() != null)
            {
                float manaPercent = (float)manaBurnedForTeleport / mana;
                EventManager.TriggerEvent(EventName.ManaChange, new EventArg(manaPercent));
            } 

        }
        else {
            Debug.Log("Not enough mana for teleportation!");
        }
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
