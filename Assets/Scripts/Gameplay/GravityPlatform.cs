using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour {
    #region Fields

    [SerializeField] private float speed = 2f;
    [SerializeField] private bool isUp;

    private Rigidbody2D rb;

    #endregion

    #region Methods

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
        isUp = false;

        AddMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Turn") {
            AddMovement();

        }
    }

    private void AddMovement() {

        if (isUp) {
            rb.velocity = Vector2.down * speed;
            isUp = false;
        }
        else {
            rb.velocity = Vector2.up * speed;
            isUp = true;
        }
    }

    #endregion
}
