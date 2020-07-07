using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    private void Start()
    {
        EventManager.TriggerEvent(EventName.AddToGameLevelObjectsList, new EventArg(gameObject));
    }

    public void SaveDestroyedObject()
    {
        EventManager.TriggerEvent(EventName.SaveMe, new EventArg(gameObject.name));
    }

}
