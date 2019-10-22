using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : CharacterController2D
{
    #region Fields

    [SerializeField] private bool isPatrol;
    [SerializeField] private bool isGuard;
    [SerializeField] private bool isCharge;
    [SerializeField] private float guardTime;
    [SerializeField] private Transform rangePoint;

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
        Raycast();
    }
    protected override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Turn") && !isGuard && isPatrol) {

            StopMovement();
            guardTimer.Run();

            isGuard = true;

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
    protected void Raycast() {

        Debug.DrawLine(atackPoint.position, rangePoint.position, Color.red);
        RaycastHit2D[] hits = Physics2D.LinecastAll(atackPoint.position, rangePoint.position);
        
        foreach(RaycastHit2D hit in hits) {

            if (hit.collider != null) {

                Charge(hit);
               
            }
        }
        

    }
    protected void Patrol() {

        if (isAlive && !isHurt) {

            if(guardTimer.Finished) {

                if(isGuard) {
                    isGuard = false;
                    if (isRight) {
                        moveX = Vector2.left.x;
    
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

    protected virtual void Charge(RaycastHit2D hit) {

        if(!isAtack) {

            foreach (string enemytag in enemyTags) {

                if (hit.transform.gameObject.CompareTag(enemytag)) {

                    if (isPatrol || isGuard) {

                        isPatrol = false;
                        isGuard = false;

                    }
                    isCharge = true;

                    RestoreMovement();

                    Debug.Log(hit.collider.name);

                }
            }
        }
  
    }
    protected virtual void AddEnemyTags() {

        enemyTags.Add("Enemy");

    }

 
}
