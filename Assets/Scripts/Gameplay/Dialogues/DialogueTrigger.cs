using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dialogue Trigger
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueContainer dialogue;

    private Transform dialogueWindow;
    private bool dialogueSet = false;

    /// <summary>
    /// Start conversation with trigger with out interact from player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {

        if(GetComponent<InteractableObject>() == null && collision.GetComponent<Player>() != null) {
            StartConversation();
        }
    }
    /// <summary>
    /// If dialogue trigger is interactable we setdialogue and invoke readyToInteract event withtrue value
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision) {

        if (GetComponent<InteractableObject>() != null && collision.GetComponent<Player>() != null) {

            if(dialogueWindow != null && !dialogueSet) {
                dialogueWindow.GetComponent<DialogueParser>().SetDialogue(dialogue);
                dialogueSet = true;
                Debug.Log("Dialogue set: " + dialogue.name);
            }
            EventManager.TriggerEvent(EventName.ReadyToInteract, new EventArg(true));
        }
    }
    /// <summary>
    /// If player exit dialogue trigger we invoke readyToInteract event with false value
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision) {

        if (GetComponent<InteractableObject>() != null && collision.GetComponent<Player>() != null) {
            EventManager.TriggerEvent(EventName.ReadyToInteract, new EventArg(false));
        }
    }
    /// <summary>
    /// Initialize dialogue window
    /// </summary>
    private void Awake() {

        // dialogueWindow = GameObject.FindGameObjectWithTag("DialogueWindow").transform;
    }

    /// <summary>
    /// Set diallogue to dialogue window
    /// Invoke StartConversation event
    /// </summary>
    private void StartConversation() {

        dialogueWindow.GetComponent<DialogueParser>().SetDialogue(dialogue);
        dialogueSet = true;
        Debug.Log("Dialogue set: " + dialogue.name);
        EventManager.TriggerEvent(EventName.StartConversation);
        Debug.Log("Starting conversation.");
    }
}
