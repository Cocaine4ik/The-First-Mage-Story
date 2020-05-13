using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MagicCharacter {

    #region Fields

    private bool canPickup = false;
    private bool isPickup = false;
    private GameObject tempPickupItem;

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
        if (isGrounded && Input.GetButtonDown("Jump") && !isPickup) {

            Jump(jumpForce);

        }

        if (canPickup && Input.GetButtonDown("Grab") && isGrounded) {

            Pickup();

            }
        }

        if(StatusUtils.GUIisActive == true) {
            Move(0);
        }
    }

    // pickup smth or collect item
    private void Pickup() {
        Item pickupItem = tempPickupItem.GetComponent<GameItem>().ItemData;

        animator.SetTrigger("Pickup");
        EventManager.TriggerEvent(EventName.PickupItem, new EventArg(pickupItem));
        // isPickup = true;
        Destroy(tempPickupItem);
        
    }

    protected override void FixedUpdate() {

        if (Input.GetAxis("Horizontal") != 0 && !isPickup && StatusUtils.GUIisActive == false 
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
    /*
    private void LateUpdate()
    {
        stats.SetMana(mana);
        stats.SetHp(hp);
    }*/
    protected void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.GetComponent<GameItem>() != null) {

            canPickup = true;
            tempPickupItem = collision.gameObject;
        }

    }
    public override void Hurt() {

        ShieldUp();
    }

    #endregion

    #region Animation Events

    private void OnCollectEnd() {
        canPickup = false;
        isPickup = false;

    }

    protected override void OnTeleport(int maxManaValue) {
        base.OnTeleport(characterMana.MaxMana);
    }
    #endregion

}
