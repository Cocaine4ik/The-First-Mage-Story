using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePortal : MonoBehaviour
{
    [SerializeField] private float appearPlayerTime;
    [SerializeField] private float portalLiveTime;

    private void Start() {

        StartCoroutine(AppearPlayer(appearPlayerTime));
    }

    /// <summary>
    /// Courutine which invoker appear player event
    /// </summary>
    /// <param name="appearPlayerTime"></param>
    /// <returns></returns>
    IEnumerator AppearPlayer(float appearPlayerTime) {

        yield return new WaitForSeconds(appearPlayerTime);
        EventManager.TriggerEvent(EventName.AppearPlayer);
        StartCoroutine(DestroyPortal(portalLiveTime));
    }

    /// <summary>
    /// Courutine whih destroys portal in the end of the cut-scene
    /// </summary>
    /// <param name="portalLiveTime"></param>
    /// <returns></returns>
    IEnumerator DestroyPortal(float portalLiveTime) {
        yield return new WaitForSeconds(portalLiveTime);
        GetComponent<Animator>().SetTrigger("Destroy");
    }
}
