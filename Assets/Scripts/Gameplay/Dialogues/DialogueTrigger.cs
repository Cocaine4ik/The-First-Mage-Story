using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dialogue Trigger
/// </summary>
public class DialogueTrigger : TalkTrigger
{
    [Header("Dialogue Options:")]
    [SerializeField] private DialogueContainer dialogue;

    private Transform dialogueWindow;
    [SerializeField] private Sprite leftSpeakerPortrait;
    [SerializeField] private Sprite rightSpeakerPortrait;
    [SerializeField] private string leftSpeakerNameKey;
    [SerializeField] private string rightSpeakerNameKey;

    public DialogueContainer Dialogue => dialogue;
    /// <summary>
    /// Start conversation with trigger with out interact from player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {

        if(isInteractable == false && isScriptable == false && collision.GetComponent<Player>() != null) {

            leftSpeakerPortrait = GetSpeakerPortrait(collision.gameObject);
            leftSpeakerNameKey = GetSpeakerNameKey(collision.gameObject);
            StartConversation();
        }
    }
    /// <summary>
    /// If dialogue trigger is interactable we setdialogue and invoke readyToInteract event withtrue value
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision) {

        if (isInteractable == true && isScriptable == false && collision.GetComponent<Player>() != null) {

            leftSpeakerPortrait = GetSpeakerPortrait(collision.gameObject);
            leftSpeakerNameKey = GetSpeakerNameKey(collision.gameObject);

            if (dialogueWindow != null && !dialogueSet) {
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

        if (isInteractable == true && isScriptable == false && collision.GetComponent<Player>() != null) {
            EventManager.TriggerEvent(EventName.ReadyToInteract, new EventArg(false));
        }
    }
    /// <summary>
    /// Initialize dialogue window
    /// </summary>
    private void Awake() {

        dialogueWindow = GameObject.FindGameObjectWithTag("DialogueWindow").transform;
    }

    private void Start() {
        if (isScriptable == true) {
            StartCoroutine(StartScriptableConversation(scriptableTime));
        }
        if(GetComponent<DialogueSpeaker>() != null)
        {
            rightSpeakerPortrait = GetSpeakerPortrait(gameObject);
            rightSpeakerNameKey = GetSpeakerNameKey(gameObject);
        }
    }
    private void OnDestroy() {
        EventManager.StopListening(EventName.ExitConversation, OnExitConversation);
    }
    /// <summary>
    /// Set diallogue to dialogue window
    /// Invoke StartConversation event
    /// </summary>
    protected override void StartConversation() {

        var parser = dialogueWindow.GetComponent<DialogueParser>();
        parser.SetDialogue(dialogue);
        dialogueSet = true;
        SetDialogueSpeakersData();
        Debug.Log("Dialogue set: " + dialogue.name);

        // set quest
        if (GetComponent<QuestGiver>() != null)
        {
            parser.SetQuest(GetComponent<QuestGiver>().QuestName);
        }

        EventManager.TriggerEvent(EventName.StartConversation);
        Debug.Log("Starting conversation.");
        EventManager.StartListening(EventName.ExitConversation, OnExitConversation);

    }

    protected override IEnumerator StartScriptableConversation(float scriptableTime) {

        yield return new WaitForSeconds(scriptableTime);
        StartConversation();
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

    private Sprite GetSpeakerPortrait(GameObject gameObject)
    {
        return gameObject.GetComponent<DialogueSpeaker>().SpeakerPortait;
    }
    private string GetSpeakerNameKey(GameObject gameObject)
    {
        return gameObject.GetComponent<DialogueSpeaker>().SpeakerNameKey;
    }

    private void SetDialogueSpeakersData()
    {
        EventManager.TriggerEvent(EventName.SetLeftSpeakerPortrait, new EventArg(leftSpeakerPortrait));
        
        EventManager.TriggerEvent(EventName.SetLeftSpeakerNameKey, new EventArg(leftSpeakerNameKey));

        if (GetComponent<DialogueSpeaker>() != null)
        {
            EventManager.TriggerEvent(EventName.SetRightSpeakerPortrait, new EventArg(rightSpeakerPortrait));
            EventManager.TriggerEvent(EventName.SetRightSpeakerNameKey, new EventArg(rightSpeakerPortrait));
        }
        else
        {
            EventManager.TriggerEvent(EventName.SetRightSpeakerPortrait, new EventArg(leftSpeakerPortrait));
            EventManager.TriggerEvent(EventName.SetRightSpeakerNameKey, new EventArg(leftSpeakerNameKey));
        }
    }
}
