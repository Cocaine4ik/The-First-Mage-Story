using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MagicCharacterController {

    #region Fields

    Attributes stats;

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
        if (Input.GetButtonDown("Fire1") && !isAtack) {

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

        Item pickupItem = GetComponent<Item>();

        animator.SetBool("CanCollect", canCollect);
        EventManager.TriggerEvent(EventName.PickupItem, new EventArg(pickupItem));
        Destroy(item);
        
    }

    protected override void FixedUpdate() {

        if(Input.GetAxis("Horizontal") != 0) {

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

    private void LateUpdate()
    {
        stats.SetMana(mana);
        stats.SetHp(hp);
    }
    protected override void OnTriggerEnter2D(Collider2D collision) {

        base.OnTriggerEnter2D(collision);

        if(collision.gameObject.GetComponent<Item>() != null) {
            canCollect = true;

            collision.gameObject.GetComponent<Item>().IsPickup = true;
            item = collision.gameObject;
        }

    }
    protected override void TakeDamage(int damage) {
        base.TakeDamage(damage);

        float healthPercent = (float)damage / stats.MaxHp;
        EventManager.TriggerEvent(EventName.HpChange, new EventArg(healthPercent));
    }

    #endregion

    #region Animation Events

    private void OnCollectEnd() {
        canCollect = false;
        animator.SetBool("CanCollect", canCollect);

    }

    protected override void OnTeleport(int maxManaValue) {
        base.OnTeleport(stats.MaxMana);
    }
    #endregion

}
