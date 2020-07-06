using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    [SerializeField] private bool withWind;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SaveData() {
        EventManager.TriggerEvent(EventName.SaveData);
        if(withWind)
        {
            animator.SetTrigger("BurnWithWind");
        }
        else
        {
            animator.SetTrigger("Burn");
        }
        Debug.Log("SaveData");
    }
}
