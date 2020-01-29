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

    private GameObject guardTurn;

    protected List<string> enemyTags;
    protected Timer guardTimer;

    #endregion

    protected override void Start() {

        base.Start();

        enemyTags = new List<string>();
        AddEnemyTags();

        guardTimer = gameObject.AddComponent<Timer>();
        guardTimer.SetTimerName(TimerName.GuardTimer);
        guardTimer.Duration = guardTime;

    }

    #region Methods

    protected override void Update() {

        base.Update();

        // raycast forward to find any coliders in front off
        Raycast();

        // if patrol is active - start patrol and write old flip
        if (isPatrol) {
            Patrol();
        }
        
        // if is guard and timer is finished it's time to change direction and off guard mode
        if (isGuard && guardTimer.Finished) {

            ChangeDirection();
            isGuard = false;

        }

        /*
        // we always try to detect enemies
        DetectEnemy();*/

    }

    /// <summary>
    /// if we colide our turn trigger we stop patrol, stop movement and on guard mode
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnTriggerEnter2D(Collider2D collision) {

        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Turn") && !isGuard && isPatrol && !isCharge && collision.gameObject != guardTurn) {

            guardTurn = collision.gameObject;
            isPatrol = false;
            isGuard = true;
            StopMovement();
            guardTimer.Run();

        }
    }

    /// <summary>
    /// if we colides with enemy we start atack him
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnCollisionStay2D(Collision2D collision) {

        base.OnCollisionStay2D(collision);

        foreach (string enemy in enemyTags) {
            if (collision.gameObject.CompareTag(enemy)) {

                Debug.Log("Atack");
                Atack();
            }
        }
    }
    /// <summary>
    /// making a ray in front off us. We are return all hits in tagets in ray way
    /// </summary>
    /// <returns></returns>
    protected RaycastHit2D[] Raycast() {

        Debug.DrawLine(atackPoint.position, rangePoint.position, Color.red);
        RaycastHit2D[] hits = Physics2D.LinecastAll(atackPoint.position, rangePoint.position);
        return hits;

    }

    /// <summary>
    /// if we are alive, and no taking damage, and no charging in enemy
    /// we continue movement but only if we can see turns in front off us
    /// </summary>
    protected void Patrol() {

        if (isAlive && !isHurt && !isCharge) {

            foreach (RaycastHit2D hit in Raycast()) {
                if (hit.transform.gameObject.CompareTag("Turn")) {

                    isPatrol = true;
                    isGuard = false;
                    RestoreMovement();

                }
            }
        }
    }
    /// <summary>
    /// Detect enemy end set our behaviour during this detection
    /// </summary>
    protected virtual void DetectEnemy() {

        if(IsAlive) {   
        

        }
    }

    /// <summary>
    /// Charging to enemy if we are not atacking. If charge off patorl and fuard is off.
    /// </summary>
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

    /// <summary>
    /// Add enemy tag for this class
    /// </summary>
    protected virtual void AddEnemyTags() {

        enemyTags.Add("Enemy");

    }

    /// <summary>
    /// Change direction 
    /// </summary>
    protected void ChangeDirection() {

        if (isRight) {
            // Debug.Log("Flip left");
            moveX = Vector2.left.x;
            isPatrol = true;

        }
        if (!isRight) {
            // Debug.Log("Flip Right");
            moveX = Vector2.right.x;
            isPatrol = true;
        }
    }

    #endregion

    #region Events

    /// <summary>
    /// Override for NPC class to off charge
    /// </summary>
    protected override void OnAtackEnd() {
        base.OnAtackEnd();
        isCharge = false;
    }

    #endregion
}
