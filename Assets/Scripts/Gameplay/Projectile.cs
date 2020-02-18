using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : AtackTrigger {

    #region Fields

    private Timer projectileDeathTimer;
    private Rigidbody2D rb;
    private LayerMask enemyLayer;

    [SerializeField] private float projectileAliveTime = 2f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject impactEffect;
    #endregion

    #region Methods

    private void Start() {

        rb = GetComponent<Rigidbody2D>();

        projectileDeathTimer = GetComponent<Timer>();
        projectileDeathTimer.SetTimerName(TimerName.ProjectileDeathTimer);
        projectileDeathTimer.Duration = projectileAliveTime;
        projectileDeathTimer.Run();

        rb.velocity = transform.right * speed;
        
    }
    // Let the rigidbody take control and detect collisions.

    private void Update() {

        if(projectileDeathTimer.Finished) {

            SelfDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.GetComponent<CharacterHealth>() != null) {

            collision.GetComponent<CharacterHealth>().TakeDamage(damage);
        }
        SelfDestroy();

    }
 

    // play impact effect animation and destroy yourself
    private void SelfDestroy() {

        Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    /*
    private void SetEnemy() {

        if (gameObject.layer == LayerMask.GetMask("Player")) {
            enemyLayer = LayerMask.GetMask("Enemy");
        }
        else {
            enemyLayer = LayerMask.GetMask("Player");
        }
    }*/
    #endregion


}
