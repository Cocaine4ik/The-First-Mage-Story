using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{

    [SerializeField] private int expRevard;

    /// <summary>
    /// Get revard for destroying object
    /// </summary>
    public void AddExpRevard()
    {
      EventManager.TriggerEvent(EventName.AddExp, new EventArg(expRevard));
    }


}
