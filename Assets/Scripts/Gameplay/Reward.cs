﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{

    [SerializeField] private int expRevard;

    /// <summary>
    /// Get revard for destroying object
    /// If object is item give reward in case it puckuped
    /// if object is enemy give reward in case is isn't alive
    /// </summary>
    private void OnDestroy()
    {
        GameItem gameItem = gameObject.GetComponent<GameItem>();
        Enemy enemy = GetComponent<Enemy>();
        
        if (gameItem != null && gameItem.IsPickup == true) {

                EventManager.TriggerEvent(EventName.AddExp, new EventArg(expRevard));
        }

        if(enemy != null && enemy.IsAlive == false) {

            EventManager.TriggerEvent(EventName.AddExp, new EventArg(expRevard));

        }

    }


}
