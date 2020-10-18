using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

/// <summary>
/// Dialogue Trigger
/// </summary>
public class DialogueTrigger : TalkTrigger
{
    private VIDE_Assign dialogue;

    /// <summary>
    /// Start conversation with trigger with out interact from player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {

        if(isInteractable == false && isScriptable == false && collision.GetComponent<Player>() != null) {

            dialogue = GetComponent<VIDE_Assign>();
            if(dialogue != null) DialogueSystem.Instance.Interact(dialogue);      
        }
    }
    /// <summary>
    /// If dialogue trigger is interactable we setdialogue and invoke readyToInteract event withtrue value
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision) {

        if (isInteractable == true && isScriptable == false && collision.GetComponent<Player>() != null) {

            if(dialogue == null) dialogue = GetComponent<VIDE_Assign>();
        }
    }
    /// <summary>
    /// If player exit dialogue trigger we invoke readyToInteract event with false value
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision) {

        if (isInteractable == true && isScriptable == false && collision.GetComponent<Player>() != null) {
            if (dialogue != null) dialogue = null;
        }
    }

    private void Update()
    {
    }
    private void OnExitConversation(EventArg arg) {
        if(isInteractable == false) {
            GetComponent<SaveMe>().SaveDestroyedObject();
            if(GetComponent<TipsSpawner>() == null)
            {
                Destroy(gameObject);
            }

        }
    }
}
