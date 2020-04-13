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

    /// <summary>
    /// Start conversation with trigger with out interact from player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {

        if(GetComponent<InteractableObject>() == null && collision.GetComponent<Player>() != null) {
            StartConversation();
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
               
    }

    /// <summary>
    /// Initialize dialogue window
    /// </summary>
    private void Awake() {

        dialogueWindow = GameObject.FindGameObjectWithTag("DialogueWindow").transform;
    }

    /// <summary>
    /// Set diallogue to dialogue window
    /// Invoke StartConversation event
    /// </summary>
    private void StartConversation() {

        dialogueWindow.GetComponent<DialogueParser>().SetDialogue(dialogue);
        Debug.Log("Dialogue set: " + dialogue.name);
        EventManager.TriggerEvent(EventName.StartConversation);
        Debug.Log("Starting conversation.");
    }
}
