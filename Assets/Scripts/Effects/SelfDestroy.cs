using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Self destroy event when animation or timer is end
/// </summary>
public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private bool instantDestroy = true;
    [SerializeField] private float selfDestroyTime;

    private void Start() {
        if(!instantDestroy) {

            StartCoroutine(DestroyAfter(selfDestroyTime));

        }
    }

    IEnumerator DestroyAfter(float timeToDestroy) {

        yield return new WaitForSeconds(timeToDestroy);
        OnSelfDestroy();
    }

    public void OnSelfDestroy() {
        Destroy(gameObject);
    }
}
