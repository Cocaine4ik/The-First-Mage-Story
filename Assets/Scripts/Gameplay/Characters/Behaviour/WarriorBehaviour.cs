using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Warrior behaviour class as a parent for another behaviours
/// </summary>
public class WarriorBehaviour : BehaviourBase {

    #region Fields

    // patrol points positions
    [SerializeField] protected Transform[] patrolPoints;
    [SerializeField] protected float turnCheckDistance = 1f;
    [SerializeField] protected float guardTime = 2f;

    // Character view range end point transform
    protected Transform rangePoint;
    protected Character character;
    protected Transform target = null;

    // variable for patrol poin choosing
    protected int nextPatrolPointNum = 0;
    // array which include points for checking if the player in patrol zone
    protected float[] patrolPointsPositionsX;

    protected bool isGuard = false;

    #endregion

    #region MonoBehaviour Methods

    /// <summary>
    /// Initialize character components and patrol points
    /// </summary>
    protected virtual void Start() {

        character = GetComponent<Character>();
        rangePoint = transform.Find("Range Point");
        InitPatrolPointsPositionsX();

    }
    /// <summary>
    /// Patrol behaviour: If character iы not on guard and have no target or target far away he patroling
    /// Guard behaviour: 
    /// If character have target and target is not far away - charge to the target
    /// </summary>
    private void FixedUpdate() {

        // patrol behaviour
        if(baseBehaviour == BaseBehaviour.Patroller) {

            if (!isGuard && target == null || !isGuard && TargetFarAway()) {
                Patrol();
            }
        }

        if (target != null && !TargetFarAway()) {
            Charge();
        }

    }
    /// <summary>
    /// Update raycast and target detecting
    /// </summary>
    protected void Update() {

        Raycast();
        DetectTarget();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Move to target if distance the distance is atack distance - atack
    /// </summary>
    protected override void Charge() {

        // calculating distance between target and character
        float distance = Vector2.Distance(target.transform.position, gameObject.transform.position);
 
        if (distance <= character.AtackWeaponData.atackRange) {
            character.Atack();
        }
        else {
            MoveToTarget(target.position.x);
        }

    }
    /// <summary>
    /// Raycast, if raycast hit layer is enemy layer set hit as a target
    /// </summary>
    protected override void DetectTarget() {
        
        if(Raycast() != null) {

            if (character.IsAlive && target == null) {

                foreach (RaycastHit2D hit in Raycast()) {

                    if (character.Enemies.Contains(hit.transform.gameObject.layer)) {

                        target = hit.transform;
                    }
                }
            }
        }
    }
    /// <summary>
    /// If target position is further then turn position - lost target and return false
    /// </summary>
    /// <returns></returns>
    protected bool TargetFarAway() {

        if(target != null) {

            if(target.position.x < patrolPointsPositionsX[0] ||
                target.position.x > patrolPointsPositionsX[patrolPointsPositionsX.Length-1]) {
                target = null;
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Stop movement and start guard courotine
    /// </summary>
    protected override void Guard() {

        StopMove();
        isGuard = true;
        StartCoroutine(StayOnGuard(guardTime));
    }

    /// <summary>
    /// Initialize patrol points horizontal positions from patrol points List 
    /// </summary>
    protected void InitPatrolPointsPositionsX() {

        if (baseBehaviour == BaseBehaviour.Patroller) {

            if (patrolPoints.Length != 0) {

                patrolPointsPositionsX = new float[patrolPoints.Length];

                for (int i = 0; i < patrolPoints.Length; i++) {

                    patrolPointsPositionsX[i] = patrolPoints[i].position.x;
                }

                patrolPointsPositionsX.BubleSort();
            }
            else {
                Debug.Log("Patrol points of the " + gameObject.name + "are not defined.");
            }
        }
    }

    /// <summary>
    /// Move from one patrol point to another and staiying on guard in it
    /// </summary>
    protected override void Patrol() {

        if (patrolPoints.Length != 0) {
    
        Transform nextPatrolPoint = patrolPoints[nextPatrolPointNum];
        MoveToTarget(nextPatrolPoint.position.x);

        if (Vector2.Distance(nextPatrolPoint.position, gameObject.transform.position) <= turnCheckDistance) {
            Guard();

            if (patrolPoints.Length - 1 > nextPatrolPointNum) {
                nextPatrolPointNum++;
            }
            else nextPatrolPointNum = 0;
            }

        }
    }

    /// <summary>
    /// Raycast and return hits array
    /// </summary>
    /// <returns></returns>
    protected RaycastHit2D[] Raycast() {

        if(rangePoint != null) {

            Debug.DrawLine(character.AtackWeapon.position, rangePoint.position, Color.red);
            RaycastHit2D[] hits = Physics2D.LinecastAll(character.AtackWeapon.position, rangePoint.position);
            return hits;

        }
        else {
            Debug.Log("Range point of the " + gameObject.name + "is not defined.");
            return null;
        }

    }

    /// <summary>
    /// Set target
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Transform target) {
        this.target = target;
    }

    /// <summary>
    /// Move to target
    /// </summary>
    /// <param name="targetPositionX"></param>
    protected void MoveToTarget(float targetPositionX) {

        float characterPositionX = gameObject.transform.position.x;

        if (targetPositionX > characterPositionX) {
            character.Move(Vector2.right.x);
        }
        else if (targetPositionX < characterPositionX) {
            character.Move(Vector2.left.x);
        }
    }

    /// <summary>
    /// Stop movement
    /// </summary>
    protected void StopMove() {

        character.Move(Vector2.zero.x);

    }

    /// <summary>
    /// Flip when movement direction changed
    /// </summary>
    protected void ChangeDirection() {

        if(character.IsRight) {
            character.Move(Vector2.left.x);
        }
        else {
            character.Move(Vector2.right.x);
        }
    }

    #endregion

    #region Courotine
    /// <summary>
    /// Wait on guard then set guard to false
    /// </summary>
    /// <param name="guardTime"></param>
    /// <returns></returns>
    protected IEnumerator StayOnGuard(float guardTime) {

            yield return new WaitForSeconds(guardTime);
            isGuard = false;
    }

    #endregion
}
