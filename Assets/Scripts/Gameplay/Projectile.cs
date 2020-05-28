using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : DamageData {

    #region Fields

    private Rigidbody2D rb;
    private LayerMask enemyLayer;
    private GameObject projectileOwner;
    private Vector2 startPos;

    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject impactEffect;
    
    #endregion

    #region Methods

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
        startPos = gameObject.transform.position;

        rb.velocity = transform.right * speed;

    }
    // Let the rigidbody take control and detect collisions.

    private void Update() {

        float distance = Vector2.Distance(startPos, gameObject.transform.position);
        
            if (Mathf.Abs(distance) >= atackRange) {
                SelfDestroy();
            }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        Debug.Log("Hit: " + collision.gameObject.name);

        if(collision.GetComponent<CharacterHealth>() != null) {

            collision.GetComponent<CharacterHealth>().TakeDamage(damage);
        }
        if(collision.GetComponentInParent<WarriorBehaviour>() != null) {

            collision.GetComponent<WarriorBehaviour>().SetTarget(projectileOwner.transform);

        }
        SelfDestroy();
    }
 
    public void SetOwner(GameObject owner) {

        projectileOwner = owner;

    }
    // play impact effect animation and destroy yourself
    private void SelfDestroy() {

        Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    #endregion


}
