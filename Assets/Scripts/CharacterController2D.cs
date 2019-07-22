using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {

    #region Fields

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 3f;

    private bool isJump = false;

    Rigidbody2D rb;
    Animator animator;

    #endregion

    #region Methods

    private void Start() {
         
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    private void Update() {
        
    }
    private void FixedUpdate() {

        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * moveX, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (Input.GetButtonDown("Jump")) {
            isJump = true;
            rb.AddRelativeForce(new Vector2(moveX, jumpForce), ForceMode2D.Impulse);
            
            animator.SetBool("IsJump", isJump);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Ground") {
            isJump = false;
            print("Test");
        }
    }
    #endregion
}
