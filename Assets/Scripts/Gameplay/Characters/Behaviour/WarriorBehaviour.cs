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
    [SerializeField] protected Transform leftChargeClamp;
    [SerializeField] protected Transform rightChargeClamp;
    [SerializeField] protected float turnCheckDistance = 1f;
    [SerializeField] protected float guardTime = 2f;

    // Character view range end point transform
    protected Transform rangePoint;
    protected Character character;
    protected Transform target = null;

    // variable for patrol poin choosing
    protected int nextPatrolPointNum = 0;

    protected bool isGuard = false;
    protected bool guardDirection;
    protected Vector2 guardPosition;

    #endregion

    #region MonoBehaviour Methods

    /// <summary>
    /// Initialize character components and patrol points
    /// </summary>
    protected virtual void Start() {

        character = GetComponent<Character>();
        rangePoint = transform.Find("Range Point");

        if (baseBehaviour == BaseBehaviour.Patroller) {
            InitDefaultChargeClampPoints();
        }

        if (baseBehaviour == BaseBehaviour.Guardian) {
            guardDirection = character.IsRight;
            guardPosition = transform.position;
        }

    }
    /// <summary>
    /// Patrol behaviour: If character iы not on guard and have no target or target far away he patroling
    /// Guard behaviour: 
    /// If character have target and target is not far away - charge to the target
    /// </summary>
    private void FixedUpdate() {

        // patrol behaviour
        if (baseBehaviour == BaseBehaviour.Patroller) {

            if (!isGuard && target == null || !isGuard && TargetFarAway()) {
                Patrol();
            }
        }

        // guard behaviour
        if (baseBehaviour == BaseBehaviour.Guardian) {

            if(target == null && !isGuard) {

                if(Vector2.Distance(transform.position, guardPosition) >= turnCheckDistance) {
                    MoveToTarget(guardPosition.x);
                }
                else {
                    Guard();
                }
            }          
        }

        // charge behaviuor
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
 
        if (distance <= character.DamageData.AtackRange) {
            character.Atack();
        }
        else {
            MoveToTarget(target.position.x);
        }
        isGuard = false;
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

            if(target.position.x < leftChargeClamp.position.x ||
                target.position.x > rightChargeClamp.position.x) {
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

        isGuard = true;

        // if character is guardian when he stay on guard he must take the right direction
        if(baseBehaviour == BaseBehaviour.Guardian) {

            if(character.IsRight != guardDirection) {
                ChangeDirection();
            }
        }

        // if character is patroller he's stat on temporary guard on patrol points
        if(baseBehaviour == BaseBehaviour.Patroller) {
            StartCoroutine(StayOnGuard(guardTime));
        }
        StopMove();
    }

    /// <summary>
    /// Initialize patrol points horizontal positions from patrol points List 
    /// </summary>
    protected void InitDefaultChargeClampPoints() {

            if(leftChargeClamp == null) {
                leftChargeClamp = patrolPoints[0];
            }

            if(rightChargeClamp == null) {
                rightChargeClamp = patrolPoints[patrolPoints.Length - 1];
            }       
    }

    /// <summary>
    /// Move from one patrol point to another and staiying on guard in it
    /// </summary>
    protected override void Patrol() {

        if (patrolPoints.Length != 0) {
    
        Transform nextPatrolPoint = patrolPoints[nextPatrolPointNum];

        if(nextPatrolPoint != null) {
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
    }

    /// <summary>
    /// Raycast and return hits array
    /// </summary>
    /// <returns></returns>
    protected RaycastHit2D[] Raycast() {

        if(rangePoint != null) {

            Debug.DrawLine(character.AtackTrigger.position, rangePoint.position, Color.red);
            RaycastHit2D[] hits = Physics2D.LinecastAll(character.AtackTrigger.position, rangePoint.position);
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
    public void MoveToTarget(float targetPositionX) {

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

    public override void ChangeLayer()
    {
        base.ChangeLayer();
    }
    #endregion
}
