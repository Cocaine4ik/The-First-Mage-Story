using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract dialogue and speech trigger class
/// </summary>
public abstract class TalkTrigger : MonoBehaviour{

    [Header("Base Talk Options:")]
    [SerializeField] protected bool isInteractable = false;
    [SerializeField] protected bool isScriptable = false;
    [SerializeField] protected float scriptableTime;

    protected bool dialogueSet = false;

    protected abstract void StartConversation();

    protected abstract IEnumerator StartScriptableConversation(float scriptableTime);

}