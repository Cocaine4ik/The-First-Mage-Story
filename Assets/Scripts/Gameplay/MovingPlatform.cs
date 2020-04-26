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
    [SerializeField] private float clampHorizontal;
    [Header("Not for editing: ")]
    [SerializeField] private bool isRight;

    [Header("Use only for vertical movement:")]
    [SerializeField] private float clampVertical;
    [Header("Not for editing: ")]
    [SerializeField] private bool isTop;

    private bool isMoveToVerticalClamp = false;
    #endregion

    #region Methods

    private void Update() {

        if (isMoveCycle == true) {

            if (!isMoveHorizontal) {

                if (transform.position.y > clampVertical) {
                    isTop = true;
                }
                else if (transform.position.y < -clampVertical) {
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

            }
        }
    }
    private void FixedUpdate() {
        
        if(isMoveToVerticalClamp == true) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, clampVertical),
                    speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(isMoveCycle == false) {
            if (collision.gameObject.GetComponent<Player>() != null) {
                isMoveToVerticalClamp = true;
            }
        }
    }
    #endregion
}
