using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MagicCharacter {

    #region Fields

    private bool canPickup = false;
    private bool canRest = false;
    private GameObject tempPickupItem;
    private SaveTrigger saveTrigger;

    #endregion

    #region Methods

    // Update is called once per frame
    protected override void Update () {

        base.Update();

        if (StatusUtils.GUIisActive == false && StatusUtils.CutScenePlaying == false) {

            // atack if atack button down
            if (Input.GetButtonDown("Fire1") && !isAtack) {

                Atack();

            }
            // teleport if teleport button down
            if (Input.GetButtonDown("Fire2")) {

                Teleport();

            }

            // jump if jump button down
            if (isGrounded && Input.GetButtonDown("Jump")) {

                Jump(jumpForce);

            }

            if (Input.GetButtonDown("Action") && isGrounded) {
                if (canPickup) {
                    Pickup();
                }
                if (canRest) {

                }

            }

            if (StatusUtils.GUIisActive == true) {
                Move(0);
            }
        }
    }

    // pickup smth or collect item
    private void Pickup() {
        Item pickupItem = tempPickupItem.GetComponent<GameItem>().ItemData;

        animator.SetTrigger("Pickup");
        EventManager.TriggerEvent(EventName.PickupItem, new EventArg(pickupItem));
        Destroy(tempPickupItem);
        
    }

    private void Rest() {
        animator.SetTrigger("Rest");
        if(saveTrigger != null) {
            saveTrigger.SaveData();
        }
    }
    protected override void FixedUpdate() {

        if (Input.GetAxis("Horizontal") != 0 && !isCast && StatusUtils.GUIisActive == false 
            && StatusUtils.CutScenePlaying == false) {

            if(!isGrounded && !jumpControlTimer.IsRunnig) {
                moveX = 0;
            }
            else {
                moveX = Input.GetAxis("Horizontal");
            }

            base.FixedUpdate();
            Move(moveX);
        }

    }
    protected void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.GetComponent<GameItem>() != null) {

            canPickup = true;
            tempPickupItem = collision.gameObject;
        }
        if(collision.gameObject.GetComponent<SaveTrigger>() != null) {
            canRest = true;
            saveTrigger = collision.gameObject.GetComponent<SaveTrigger>();
        }
    }
    protected void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<SaveTrigger>() != null) {
            canRest = false;
            saveTrigger = null;
        }
    }
    public override void Hurt() {

        ShieldUp();
    }

    #endregion

    #region Animation Events

    private void OnPickupEnd() {
        canPickup = false;
        tempPickupItem = null;
    }
    protected override void OnTeleport(int maxManaValue) {
        base.OnTeleport(characterMana.MaxMana);
    }
    #endregion

}
