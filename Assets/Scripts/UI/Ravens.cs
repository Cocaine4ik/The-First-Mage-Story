using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ravens : MonoBehaviour
{

    private BoxCollider2D collider2D;

    private float colliderWidth;
    private float colliderHeight;


    public float ColliderWidth {
        get { return colliderWidth; }
    }

    public float ColliderHeight {
        get { return colliderHeight; }
    }

    #region Methods

    private void Start() {

        collider2D = GetComponent<BoxCollider2D>();

        colliderWidth = collider2D.size.x;
        colliderHeight = collider2D.size.y;
    }
    private void Update() {

        if (gameObject.transform.position.x + colliderWidth  < ScreenUtils.ScreenLeft) {
            EventManager.TriggerEvent(EventName.SpawnRavens, new EventArg());
            Destroy(gameObject);
        }

    }

    #endregion
}
