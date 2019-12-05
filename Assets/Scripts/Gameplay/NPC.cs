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
            oldIsRight = isRight;
        }

        // if is guard and timer is finished it's time to change direction and off guard mode
        if (isGuard && guardTimer.Finished) {

            ChangeDirection();
            isGuard = false;

        }

        // if we change direction (old isRight is not equal new) so we continue patrol
        if(oldIsRight != isRight && !isCharge) {
            isPatrol = true;
        }

        // we always try to detect enemies
        DetectEnemy();
    }

    /// <summary>
    /// if we colide our turn trigger we stop patrol, stop movement and on guard mode
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Turn") && !isGuard && isPatrol) {

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
    protected virtual void OnCollisionEnter2D(Collision2D collision) {
        
        foreach(string enemy in enemyTags) {
            if (collision.gameObject.CompareTag(enemy)) {

                StopMovement();
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

       
        int enemiesInRange = 0;
        bool turnInRange = false;

        foreach (RaycastHit2D hit in Raycast()) {

            // For each hit in raycast checking if it is enemy, if is true we add enemy to variable enemiesInRange. 
            foreach (string enemytag in enemyTags) {

                    if (hit.transform.gameObject.CompareTag(enemytag)) {

                    enemiesInRange++;    
                    
                    }
            }
            // If we have a turn in hit we set turn is true to variable turnInRange.
            if (hit.transform.gameObject.CompareTag("Turn")) {

                turnInRange = true;
            }

        }

        // Debug.Log(enemiesInRange);
        // if we have turn in range and more then 0 enemeis we charging.
        if (enemiesInRange > 0 && turnInRange) {
            Charge();
        }

        // if we havn't turn in range we stop movement and changing direction.
        else if (!turnInRange) {
            StopMovement();
            ChangeDirection();
        }
        else {
            // If we havn't enemies in range and we have a hurt we change direction.
            if (isHurt) {

                ChangeDirection();
            }
            // if enemie is lost we stop charge and continue patrol
                if (isCharge && !isGuard && !isPatrol && !isAtack) {
                    isPatrol = true;
                    isCharge = false;
                }
            }
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

        }
        if (!isRight) {
            // Debug.Log("Flip Right");
            moveX = Vector2.right.x;
        }
    }

    protected override void StopMovement() {
        base.StopMovement();
 
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
