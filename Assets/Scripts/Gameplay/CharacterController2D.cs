using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : Character {

    #region Fields

    protected Rigidbody2D rb;
    protected Animator animator;

    protected bool isRight;
    protected bool isAtack = false;

    protected float moveX;

    private bool atackPointTransfered = false;
    #endregion

    #region Methods

    protected virtual void Start() {

         // init rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isRight = true;

    }

    protected virtual void FixedUpdate() {

        Flip(moveX);
  
    }

    protected override void Move(float moveX) {

        if (isAtack == false) { 
            rb.velocity = new Vector2(speed * moveX, rb.velocity.y);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveX));
    }

    protected void Flip(float moveX) {

        if(moveX > 0 && !isRight || moveX < 0 && isRight) {

            isRight = !isRight;

            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }


    }
    protected override void Atack() {

        isAtack = true;
        animator.SetBool("IsAtack", isAtack);

    }

    protected override void Hurt() {
        throw new System.NotImplementedException();
    }

    protected override void Die() {
        throw new System.NotImplementedException();
    }

    #endregion

    #region Animation Events

    // if atack end stop animation
    protected void OnAtackEnd() {
        isAtack = false;
        animator.SetBool("IsAtack", isAtack);
    }

    #endregion
}
