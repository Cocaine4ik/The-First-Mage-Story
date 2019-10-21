using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : CharacterController2D
{
    [SerializeField] private bool isPatrol;
    [SerializeField] private bool isGuard;
    [SerializeField] private float guardTime;
    private Timer guardTimer;

    protected override void Start() {

        base.Start();

        guardTimer = GetComponent<Timer>();
        guardTimer.SetTimerName(TimerName.GuardTimer);
        guardTimer.Duration = guardTime;


        if (!isGuard) {

            if (isRight) {
                moveX = Vector2.right.x;
            }
            else {
                moveX = Vector2.left.x;
            }
        }


    }
    protected override void Update() {
        base.Update();
        if (isPatrol) {
            Patrol();
        }

    }
    protected override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Turn") && !isGuard) {

            moveX = Vector2.zero.x;
            guardTimer.Run();

            isGuard = true;

        }
    }
    protected void Patrol() {

        if (isAlive && !isHurt) {

            if(guardTimer.Finished) {

                if(isGuard) {
                    if (isRight) {
                        moveX = Vector2.left.x;
                        isGuard = false;
                    }

                    else if (!isRight) {
                        moveX = Vector2.right.x;
                        isGuard = false;
                    }
                }

            }
            Move(moveX);
        }

    }
}
