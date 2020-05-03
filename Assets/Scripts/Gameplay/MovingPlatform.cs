using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    #region Fields

    [Header("Moving Platfrom Settings:")]
    [SerializeField] private float speed = 2f;
    [Header("Move cycle based on settings.")]
    [SerializeField] private bool isMoveCycle = true;

    [Header("Use only for horizontal movement:")]
    [SerializeField] private bool isMoveHorizontal;
    [SerializeField] private float clampHorizontalRight;
    [SerializeField] private float clampHorizontalLeft;

    [Header("Not for editing: ")]
    [SerializeField] private bool isRight;

    [Header("Use only for vertical movement:")]
    [SerializeField] private float clampVerticalTop;
    [SerializeField] private float clampVerticalButton;
    [Header("Not for editing: ")]
    [SerializeField] private bool isTop;

    private bool isMoveToVerticalClamp = false;
    #endregion

    #region Methods

    private void Update() {

        if (isMoveCycle == true) {

            if (!isMoveHorizontal) {

                if (transform.position.y > clampVerticalTop) {
                    isTop = true;
                }
                else if (transform.position.y < clampVerticalButton) {
                    isTop = false;
                }

                if (isTop == true) {
                    transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
                }
                else {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
                }
            }
            else if (isMoveHorizontal) {
                if (transform.position.x > clampHorizontalRight) {
                    isRight = true;
                }
                else if (transform.position.x < clampHorizontalLeft) {
                    isRight = false;
                }

                if (isRight == true) {
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                }
                else {
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y );
                }
            }
        }
    }
    private void FixedUpdate() {
        
        if(isMoveToVerticalClamp == true) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, clampVerticalTop),
                    speed * Time.deltaTime);
        }
    }
    public void MoveUp() {
        
        if(isMoveCycle == false) {
                isMoveToVerticalClamp = true;
        }
    }
    #endregion
}
