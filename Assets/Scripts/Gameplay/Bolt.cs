using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

    #region Fields

    private Timer boltDeathTimer;
    private Rigidbody2D rb;
    private Animator animator;

    private float direction = 1;

    [SerializeField] private float boltAliveTime = 2f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject impactEffect;
    #endregion

    #region Methods

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        boltDeathTimer = GetComponent<Timer>();
        boltDeathTimer.SetTimerName(TimerName.BoltDeathTimer);
        boltDeathTimer.Duration = boltAliveTime;
        boltDeathTimer.Run();

        rb.velocity = transform.right * speed;
        
    }
    // Let the rigidbody take control and detect collisions.

    private void Update() {

        if(boltDeathTimer.Finished) {

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
