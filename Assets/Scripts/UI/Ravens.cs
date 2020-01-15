using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ravens : MonoBehaviour
{

    private BoxCollider2D collider2D;


    #region Methods

    private void Start() {

        collider2D = GetComponent<BoxCollider2D>();
    }
    private void Update() {

        /*
        if (gameObject.transform.position.x + collider2D.size.x;  < ScreenUtils.ScreenLeft) {
            EventManager.TriggerEvent(EventName.SpawnRavens, new EventArg());
            Destroy(gameObject);
        }
        */
    }

    #endregion
}
