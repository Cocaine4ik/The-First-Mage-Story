using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move object in left or right direction with custom speed and angle
/// </summary>
public class MovementEffect : MonoBehaviour
{
    #region Enum

    private enum MoveDirection {

        left,
        right
    }

    #endregion

    #region Fields

    [SerializeField] private float speed = 2;
    [SerializeField] private MoveDirection moveDirection;
    [SerializeField] private float angle = 0;

    private Rigidbody2D rb;
    private Vector2 direction;

    #endregion

    #region Methods

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch(moveDirection) {
            case MoveDirection.left: direction = Vector2.left; break;
            case MoveDirection.right: direction = Vector2.right; break;
        }

        
        direction.y += angle;

    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = direction * speed * Time.deltaTime;
    }

    #endregion
}
