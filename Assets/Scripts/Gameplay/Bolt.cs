using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

    #region Fields

    private Timer boltDeathTimer;
    private Rigidbody2D rb;

    private float direction = 1;

    [SerializeField] private float boltAliveTime = 2f;
    [SerializeField] private float forcePower = 5f;

    #endregion

    #region Methods

    private void Start() {

        rb = GetComponent<Rigidbody2D>();

        boltDeathTimer = GetComponent<Timer>();
        boltDeathTimer.SetTimerName(TimerName.BoltDeathTimer);
        boltDeathTimer.Duration = boltAliveTime;
        boltDeathTimer.Run();

        rb.AddForce(new Vector2(direction * forcePower, 0), ForceMode2D.Impulse);
    }

    private void Update() {

        if(boltDeathTimer.Finished) {

            Destroy(gameObject);
        }
    }
    private void AddForce() {

    }
    #endregion


}
