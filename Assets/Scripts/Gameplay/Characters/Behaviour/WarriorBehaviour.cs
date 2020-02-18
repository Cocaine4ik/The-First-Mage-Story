using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBehaviour : BehaviourBase {


    // Character view range end point transform
    [SerializeField] protected Transform rangePoint;
    [SerializeField] protected Transform[] patrolPoints;
    [SerializeField] protected float turnCheckDistance = 1f;
    [SerializeField] protected float guardTime = 2f;

    protected Character character;
    protected Transform target = null;
    protected int nextPatrolPointNum = 0;


    protected bool isGuard = false;

    protected override void Charge() {

        float distance = Vector2.Distance(target.transform.position, gameObject.transform.position);
 
        if (distance <= character.AtackTrigger.atackRange) {
            character.Atack();
        }
        else {
            MoveToTarget(target.position.x);
        }

    }

    protected override void DetectTarget() {
        
        if(character.IsAlive) {
            foreach (RaycastHit2D hit in Raycast()) {

                if (character.Enemies.Contains(hit.transform.gameObject.layer)) {

                    target = hit.transform;
                    Debug.Log(target);
                    break;
                }
                else target = null;
            }
        }
    }

    protected override void Guard() {

        StopMove();
        isGuard = true;
        StartCoroutine(StayOnGuard(guardTime));
    }

    protected override void Patrol() {

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

    protected RaycastHit2D[] Raycast() {

        Debug.DrawLine(transform.position, rangePoint.position, Color.red);
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, rangePoint.position);
        return hits;

    }

    protected void MoveToTarget(float targetPositionX) {

        float characterPositionX = gameObject.transform.position.x;

        if (targetPositionX > characterPositionX) {
            character.Move(Vector2.right.x);
        }
        else if (targetPositionX < characterPositionX) {
            character.Move(Vector2.left.x);
        }
    }

    protected void StopMove() {

        character.Move(Vector2.zero.x);

    }
    protected IEnumerator StayOnGuard(float guardTime) {

            yield return new WaitForSeconds(guardTime);
            isGuard = false;
    }
    protected virtual void Start() {

        character = GetComponent<Character>();

    }
    private void FixedUpdate() {

        if(!isGuard && target == null) {
            Patrol();
        }

        if (target != null) {
            Charge();
        }

    }
    protected void Update() {

        Raycast();
        DetectTarget();
    }
}
