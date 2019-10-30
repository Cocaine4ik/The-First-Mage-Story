using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : CharacterController2D
{
    #region Fields

    [SerializeField] private bool isPatrol;
    [SerializeField] private bool isGuard;
    [SerializeField] protected bool isCharge;
    [SerializeField] private float guardTime;
    [SerializeField] private Transform rangePoint;

    private bool oldIsRight;

    protected List<string> enemyTags;
    protected Timer guardTimer;

    #endregion

    protected override void Start() {

        base.Start();

        enemyTags = new List<string>();
        AddEnemyTags();

        guardTimer = GetComponent<Timer>();
        guardTimer.SetTimerName(TimerName.GuardTimer);
        guardTimer.Duration = guardTime;

    }
    protected override void Update() {

        base.Update();



        Raycast();
        if (isPatrol) {
            Patrol();
            oldIsRight = isRight;
        }

        if (isGuard && guardTimer.Finished) {


            ChangeDirection();
            isGuard = false;

        }
        if(oldIsRight != isRight && !isCharge) {
            isPatrol = true;
        }

        DetectEnemy();
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Turn") && !isGuard && isPatrol) {

            isPatrol = false;
            isGuard = true;
            StopMovement();
            guardTimer.Run();

        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision) {
        
        foreach(string enemy in enemyTags) {
            if (collision.gameObject.CompareTag(enemy)) {

                StopMovement();
                Debug.Log("Atack");
                Atack();
            }
        }

    }
    protected RaycastHit2D[] Raycast() {

        Debug.DrawLine(atackPoint.position, rangePoint.position, Color.red);
        RaycastHit2D[] hits = Physics2D.LinecastAll(atackPoint.position, rangePoint.position);
        return hits;

    }
    protected void Patrol() {

        if (isAlive && !isHurt && !isCharge) {

            foreach (RaycastHit2D hit in Raycast()) {
                if (hit.transform.gameObject.CompareTag("Turn")) {
                    RestoreMovement();
                }
            }

        }
    }

    protected virtual void DetectEnemy() {

        int enemiesInRange = 0;

        foreach (RaycastHit2D hit in Raycast()) {

                foreach (string enemytag in enemyTags) {

                    if (hit.transform.gameObject.CompareTag(enemytag)) {

                    enemiesInRange++;    
                    
                    }
                }
        }
        // Debug.Log(enemiesInRange);

        if(enemiesInRange > 0) {
            Charge();
        }
        else {
            if(isHurt) {

                ChangeDirection();
            }
            else {
                isCharge = false;
            }

        }
    }

    protected void Charge() {

        if (!isAtack) {

            isCharge = true;

            if (isPatrol) {

                isPatrol = false;

            }

            if (isGuard) {

                isGuard = false;


            }
            RestoreMovement();

        }
    }
    protected virtual void AddEnemyTags() {

        enemyTags.Add("Enemy");

    }

    protected override void OnAtackEnd() {
        base.OnAtackEnd();
        isCharge = false;
    }

    protected void ChangeDirection() {

        if (isRight) {
            Debug.Log("Flip left");
            moveX = Vector2.left.x;

        }
        if (!isRight) {
            Debug.Log("Flip Right");
            moveX = Vector2.right.x;
        }
    }

}
