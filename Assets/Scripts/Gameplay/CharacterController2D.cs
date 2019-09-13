using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class CharacterController2D : Character {

    #region Fields

    protected Rigidbody2D rb;
    protected Animator animator;

    [SerializeField] protected bool isRight = true;

    protected bool isAlive = true;
    protected bool isAtack = false;
    protected bool isHurt = false;
    protected bool isJump = false;

    protected bool isGrounded;

    [SerializeField] protected Transform feetPos;
    [SerializeField] protected float checkRadius;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected LayerMask whatIsGround;

    protected float moveX;

    #endregion

    #region Properties

    public int Hp { get { return hp; } }
    public int CurrentHp { get { return currentHp; } }

    public bool IsAlive {  get { return IsAlive; } }

    #endregion
    #region Methods

    protected virtual void Start() {

         // init rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
                   
        animator.SetBool("IsAlive", isAlive);

        currentHp = Hp;

    }

    protected virtual void Update() {
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

        Flip(moveX);
  
    }

    protected override void Move(float moveX) {

        if (isAtack == false) { 
            rb.velocity = new Vector2(speed * moveX, rb.velocity.y);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveX));
    }

    // flip left and right
    protected override void Flip(float moveX) {

        if(moveX > 0 && !isRight || moveX < 0 && isRight) {

            isRight = !isRight;
            transform.Rotate(0, 180, 0);
        }


    } 
    // set atack is true and play atack animation
    protected override void Atack() {

        isAtack = true;
        animator.SetBool("IsAtack", isAtack);

    }

    protected override void Jump(float jumpForce) {

        rb.velocity = Vector2.up * jumpForce;

    }

    protected override void Hurt() {
        isHurt = true;
        animator.SetBool("IsHurt", isHurt);
    }

    protected override void Die() {
        
        if(hp <= 0) {
            isAlive = false;
            animator.SetBool("IsAlive", isAlive);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Projectile") {
            int receivedDamage = collision.gameObject.GetComponent<Projectile>().Damage;
            TakeDamage(receivedDamage);
            Hurt();
        }
    }
    protected override void TakeDamage(int damage) {

        hp = hp - damage;
    }

    #endregion


    #region Animation Events

    // if atack end stop animation
    protected void OnAtackEnd() {
        isAtack = false;
        animator.SetBool("IsAtack", isAtack);
    }

    protected void OnHurt() {
        isHurt = false;
        animator.SetBool("IsHurt", isHurt);

    }
    // left the body after death
    protected void OnDeath() {
        Instantiate(corpse, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    #endregion
}
