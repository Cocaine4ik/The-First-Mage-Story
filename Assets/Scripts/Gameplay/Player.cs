using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MagicCharacterController {

    #region Fields

    private bool canCollect = false;
    private GameObject item;

    [SerializeField] private int expToReachLevel;
    #endregion

    #region Properties

    #endregion

    #region Methods

    // Update is called once per frame
    protected override void Update () {

        base.Update();

        // atack if atack button down
        if (Input.GetButtonDown("Fire1")) {

            Atack();
           
        }
        // teleport if teleport button down
        if (Input.GetButtonDown("Fire2")) {

            Teleport();

        }
        // jump if jump button down
        if(isGrounded && Input.GetButtonDown("Jump")) {

            Jump(jumpForce);

        }

        if (canCollect && Input.GetButtonDown("Grab")) {

            Pickup();

        }

    }

    // pickup smth or collect item
    private void Pickup() {

        Item pickupItem = GetComponent<Item>();

        animator.SetBool("CanCollect", canCollect);
        EventManager.TriggerEvent(EventName.PickupItem, new EventArg(pickupItem));
        Destroy(item);
        
    }
    protected override void FixedUpdate() {

        moveX = Input.GetAxis("Horizontal");
        base.FixedUpdate();
        Move(moveX);
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {

        base.OnTriggerEnter2D(collision);

        if(collision.gameObject.GetComponent<Item>() != null) {
            canCollect = true;

            item = collision.gameObject;
        }

    }

    #endregion

    #region Animation Events

    private void OnCollectEnd() {
        canCollect = false;
        animator.SetBool("CanCollect", canCollect);

    }

    #endregion

}
