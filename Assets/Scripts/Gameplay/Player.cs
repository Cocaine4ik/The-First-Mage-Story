using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MagicCharacter {

    #region Fields

    Attributes stats;

    private bool canPickup = false;
    private bool isPickup = false;
    private GameObject tempPickupItem;

    [SerializeField] private int expToReachLevel;
    #endregion

    #region Properties

    #endregion

    #region Methods

    // Update is called once per frame
    protected override void Update () {

        base.Update();

        // atack if atack button down
        if (Input.GetButtonDown("Fire1") && !isAtack && StatusUtils.InventoryClosed) {

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

        if (Input.GetKeyDown(KeyCode.F5)) {
            stats.SavePlayer();
        }

        if(Input.GetKeyDown(KeyCode.F6)) {
            stats.LoadPlayer();
        }

    }

    protected override void Start() {
        base.Start();
        stats = GetComponent<Attributes>();
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

        if (Input.GetAxis("Horizontal") != 0 && !isPickup) {

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
    protected override void OnTriggerEnter2D(Collider2D collision) {

        base.OnTriggerEnter2D(collision);

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
        base.OnTeleport(stats.MaxMana);
    }
    #endregion

}
