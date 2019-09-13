using System.Collections;
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
        Item item = gameObject.GetComponent<Item>();
        Enemy enemy = GetComponent<Enemy>();
        
        if (item != null && item.IsPickup == true) {

                EventManager.TriggerEvent(EventName.AddExp, new EventArg(expRevard));
        }

        if(enemy != null && enemy.IsAlive == false) {

            if(gameObject.GetComponent<Enemy>().IsAlive == false) {

                EventManager.TriggerEvent(EventName.AddExp, new EventArg(expRevard));
            }
        }

    }


}
