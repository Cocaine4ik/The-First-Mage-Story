﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCharacter : RangeCharacter{

    #region Fields

    protected CharacterMana characterMana;
    
    [SerializeField] protected GameObject magicShield;
    protected GameObject activeShield;
    [SerializeField] protected int manaPerTeleport = 5;
    protected Vector2 teleportPosition;

    protected bool isTeleportedIn = false;
    protected bool isTeleportedOut = false;

    #endregion

    #region Methods

    protected override void Start() {

        base.Start();
        characterMana = GetComponent<CharacterMana>();

    }

    protected void ShieldUp() {

        if(activeShield == null) {
            activeShield = Instantiate(magicShield, gameObject.transform);
        }

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

    protected virtual void OnTeleport(int maxManaValue) {

        isTeleportedIn = false;
        animator.SetBool("IsTeleportedIn", isTeleportedIn);

        int manaBurnedForTeleport = ManaBurnedForTeleport(teleportPosition);

        if (characterMana.CurrentMana >= manaBurnedForTeleport) {

            characterMana.BurnMana(manaBurnedForTeleport);

            TeleportToPoint(teleportPosition);
            isTeleportedOut = true;
            animator.SetBool("IsTeleportedOut", isTeleportedOut);

            if(GetComponent<Player>() != null)
            {
                float manaPercent = (float)manaBurnedForTeleport / maxManaValue;
                EventManager.TriggerEvent(EventName.ManaChange, new EventArg(manaPercent));
            } 

        }
    }

    protected void OutTeleport() {
        isTeleportedOut = false;
        animator.SetBool("IsTeleportedOut", isTeleportedOut);
    }

    #endregion
}