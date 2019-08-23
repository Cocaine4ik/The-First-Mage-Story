using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MagicCharacterController {


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
    }

    protected override void FixedUpdate() {

        moveX = Input.GetAxis("Horizontal");
        base.FixedUpdate();
        Move(moveX);
    }

    #endregion
}
