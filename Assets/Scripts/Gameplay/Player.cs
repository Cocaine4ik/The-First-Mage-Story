using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MagicCharacterController {

    private bool canCollect = false;
    private int ExpToLevelUp;
    private GameObject item;

    #region Methods

    private void OnEnable()
    {
        EventManager.StartListening(EventName.LevelUp, )
    }
    protected override void Start()
    {
        base.Start();
        
    }
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

    /// <summary>
    /// Set exp
    /// </summary>
    /// <param name="expAmount"></param>
    public void SetExp(int expAmount)
    {
        exp = expAmount;
    }
    /// <summary>
    /// level up
    /// </summary>
    private void OnLevelUp(EventArg arg)
    {
        lvl = arg.FirstIntArg;
    }
    #endregion

    #region Animation Events

    private void OnCollectEnd() {
        canCollect = false;
        animator.SetBool("CanCollect", canCollect);

    }

    #endregion

}
