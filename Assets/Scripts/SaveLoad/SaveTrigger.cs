using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    public void SaveData() {
        EventManager.TriggerEvent(EventName.SaveData);
        Debug.Log("SaveData");
    }
}
