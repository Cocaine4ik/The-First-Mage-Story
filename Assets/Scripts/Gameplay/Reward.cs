using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private int expRevard;

    private void OnDestroy()
    {
        EventManager.TriggerEvent(EventName.AddExp, new EventArg(expRevard));
    }
}
