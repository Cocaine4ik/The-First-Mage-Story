using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    private enum MoveDirection {

        left,
        right
    }

    [SerializeField] private float speed = 2;
    [SerializeField] private MoveDirection moveDirection;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch(moveDirection) {
            case MoveDirection.left: direction = Vector2.left; break;
            case MoveDirection.right: direction = Vector2.right; break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = direction * speed * Time.deltaTime;
    }
}
