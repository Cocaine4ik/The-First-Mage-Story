using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffect : MonoBehaviour
{
    private enum MoveDirection {

        left,
        right
    }

    [SerializeField] private float speed = 2;
    [SerializeField] private MoveDirection moveDirection;
    [SerializeField] private float angle = 0;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch(moveDirection) {
            case MoveDirection.left: direction = Vector2.left; break;
            case MoveDirection.right: direction = Vector2.right; break;
        }

        
        direction.y += angle;

        if ((Camera.main.pixelHeight) > 300) {
            speed *= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = direction * speed * Time.deltaTime;
    }

    private void OnBecameInvisible() {

        Destroy(gameObject);
    }
}
