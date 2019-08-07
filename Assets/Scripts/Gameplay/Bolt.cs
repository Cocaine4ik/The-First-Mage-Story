using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

    #region Fields

    private Timer boltDeathTimer;
    private Rigidbody2D rb;

    private float direction = 1;

    [SerializeField] private float boltAliveTime = 2f;
    [SerializeField] private float speed = 5f;

    #endregion

    #region Methods

    private void Start() {

        rb = GetComponent<Rigidbody2D>();

        boltDeathTimer = GetComponent<Timer>();
        boltDeathTimer.SetTimerName(TimerName.BoltDeathTimer);
        boltDeathTimer.Duration = boltAliveTime;
        boltDeathTimer.Run();

        rb.velocity = transform.right * speed;
    }

    private void Update() {

        if(boltDeathTimer.Finished) {

            Destroy(gameObject);
        }
    }

    #endregion


}
