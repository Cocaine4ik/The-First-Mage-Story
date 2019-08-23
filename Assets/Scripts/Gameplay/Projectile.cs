using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    #region Fields

    private Timer projectileDeathTimer;
    private Rigidbody2D rb;

    [SerializeField] private float projectileAliveTime = 2f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage;
    [SerializeField] private GameObject impactEffect;
    #endregion

    #region Properties

    public int Damage {
        get { return damage; }
    }

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

        SelfDestroy();

    }
    // play impact effect animation and destroy yourself
    private void SelfDestroy() {

        Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    #endregion


}
