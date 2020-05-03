using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEffect : MonoBehaviour
{
    private float speed = 0.1f;
    private float clamp = 0.1f;
    private bool moveTop = true;

    private float defaultY;
    // Start is called before the first frame update
    void Start()
    {
        defaultY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > defaultY + clamp) {
            moveTop = false;

        }
        else if(transform.position.y < defaultY) {
            moveTop = true;
        }       
        if(moveTop == true) {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (moveTop == false) {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
