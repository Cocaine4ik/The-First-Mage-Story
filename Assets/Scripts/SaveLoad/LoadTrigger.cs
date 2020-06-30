using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    public void LoadData() {
        EventManager.TriggerEvent(EventName.LoadScene);
    }

}
