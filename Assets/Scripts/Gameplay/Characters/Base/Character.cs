﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterBase {

    #region Fields

    [SerializeField] protected Transform atackPoint;
    [SerializeField] protected GameObject corpse;
    [SerializeField] protected float speed = 5f;
    // Enemy layers for mellee atack checking
    [SerializeField] protected LayerMask enemies;

    protected Rigidbody2D rb;
    protected Animator animator;
    protected Timer jumpControlTimer;
    protected AtackTrigger atackTrigger;

    [SerializeField] protected bool isRight = true;

    protected bool isAlive = true;
    protected bool isHurt = false;
    protected bool isAtack = false;
    protected bool isJump = false;

    protected bool isGrounded;

    [SerializeField] protected Transform feetPos;
    [SerializeField] protected float checkRadius;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float jumpControlTime;
    [SerializeField] protected LayerMask whatIsGround;

    protected float moveX;

    #endregion

    #region Properties

    public bool IsAlive => isAlive;
    public bool IsHurt => isHurt;
    public LayerMask Enemies => enemies;
    public AtackTrigger AtackTrigger => atackTrigger;
    public bool IsRight => isRight;

    #endregion

    #region Methods

    protected virtual void Start() {

         // init rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterHealth = GetComponent<CharacterHealth>();
        atackTrigger = atackPoint.gameObject.GetComponent<AtackTrigger>();
                   
        animator.SetBool("IsAlive", isAlive);

        jumpControlTimer = gameObject.AddComponent<Timer>();
        jumpControlTimer.SetTimerName(TimerName.JumpControlTimer);
        jumpControlTimer.Duration = jumpControlTime;
    }

    protected virtual void Update() {

        // Die if it's time to...
        Die();

        // ground controll
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
        // jump controllling
        if (isGrounded) {
            isJump = false;
            animator.SetBool("IsJump", isJump);

        }
        else {
            isJump = true;
            animator.SetBool("IsJump", isJump);
        }
    }

    protected virtual void FixedUpdate() {

        // flip if X movement direction is changed
        Flip(moveX);
  
    }

    public override void Move(float moveX) {

        if (!isAtack && isAlive) {
            this.moveX = moveX;
            rb.velocity = new Vector2(speed * moveX, rb.velocity.y);
        }

            animator.SetFloat("Speed", Mathf.Abs(moveX));
 
    }

    // flip left and right
    protected override void Flip(float moveX) {

        if(IsAlive) {

            if (moveX > 0 && !isRight || moveX < 0 && isRight) {

                isRight = !isRight;
                transform.Rotate(0, 180, 0);

            }
        }

    }
    // set atack is true and play atack animation
    public override void Atack() {

        isAtack = true;
        animator.SetBool("IsAtack", isAtack);

    }

    protected override void Jump(float jumpForce) {

        rb.velocity = Vector2.up * jumpForce;
        jumpControlTimer.Run();

    }

    public override void Hurt() {

        animator.SetTrigger("Hurt");
        isHurt = true;
    }

    /// <summary>
    /// Die if is not alive
    /// </summary>
    protected override void Die() {
        
        if(characterHealth.CurrentHealth <= 0) {
            isAlive = false;
            animator.SetBool("IsAlive", isAlive);
        }
    }
  
    protected virtual void OnTriggerEnter2D(Collider2D collision) {

        CheckDamage(collision, "Projectile");
    }
    
    protected virtual void OnCollisionStay2D(Collision2D collision) {

        CheckDamage(collision, "Disaster");
    }
    /// <summary>
    /// Check Damage
    /// Checking if collision object is euqal damager tag, take damage, play hurt animation
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="damagerTag"></param>
    /// 
    private void CheckDamage(Collision2D collision, string damagerTag) {

        if (collision.gameObject.tag == damagerTag) {

            int receivedDamage = collision.gameObject.GetComponent<AtackTrigger>().Damage;
            characterHealth.TakeDamage(receivedDamage);
            Hurt();
        }
    }

    /// <summary>
    /// Check Damage for triggers
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="damagerTag"></param>
    private void CheckDamage(Collider2D collision, string damagerTag) {

        if (collision.gameObject.tag == damagerTag) {

            int receivedDamage = collision.gameObject.GetComponent<AtackTrigger>().Damage;
            characterHealth.TakeDamage(receivedDamage);
            Hurt();
        }
    }
    #endregion


    #region Animation Events

    protected void OnAtack() {

        Collider2D targetColider = Physics2D.OverlapCircle(transform.position, atackTrigger.atackRange, enemies);

        if(targetColider != null) {
            targetColider.GetComponent<CharacterHealth>().TakeDamage(atackTrigger.Damage);
        }
    }
    // if atack end stop animation
    protected void OnAtackEnd() {

        isAtack = false;
        animator.SetBool("IsAtack", isAtack);
    }

    // left the body after death
    protected void OnDeath() {
        Instantiate(corpse, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    protected void OnHurtEnd() {
        isHurt = false;
    }
    #endregion
}
