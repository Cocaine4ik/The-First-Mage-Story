using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ravens : MonoBehaviour
{
    private void OnBecameInvisible() {

        EventManager.TriggerEvent(EventName.SpawnRavens, new EventArg());
        Destroy(gameObject);

    }
}
