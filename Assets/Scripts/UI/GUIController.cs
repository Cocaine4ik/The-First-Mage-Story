using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main GUI class to control and manage player interface
/// </summary>
public class GUIController : MonoBehaviour {

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject dialogueWindow;
    [SerializeField] private GameObject QuestJournal;

    private List<GameObject> inventoryChilds;
    private List<GameObject> dialogueWindowChilds;
    private List<GameObject> questJournalChilds;

    private bool readyToInteract = false;

    private void OnEnable() {

        EventManager.StartListening(EventName.StartConversation, StartOrExitConversationEvent);
        EventManager.StartListening(EventName.ExitConversation, StartOrExitConversationEvent);
        EventManager.StartListening(EventName.ReadyToInteract, ReadyToInteractEvent);
        EventManager.StartListening(EventName.CloseQuestJournal, CloseQuestJournalEvent);

    }
    private void OnDisable() {

        EventManager.StopListening(EventName.StartConversation, StartOrExitConversationEvent);
        EventManager.StopListening(EventName.ExitConversation, StartOrExitConversationEvent);
        EventManager.StopListening(EventName.ReadyToInteract, ReadyToInteractEvent);
        EventManager.StopListening(EventName.CloseQuestJournal, CloseQuestJournalEvent);

    }
    private void Start() {

        inventoryChilds = UnityExtensions.CreateChildsList(inventory.transform);
        dialogueWindowChilds = UnityExtensions.CreateChildsList(dialogueWindow.transform);
        questJournalChilds = UnityExtensions.CreateChildsList(QuestJournal.transform);

        OpenCloseGUIElement(inventoryChilds);
        OpenCloseGUIElement(dialogueWindowChilds);
        OpenCloseGUIElement(questJournalChilds);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {

            OpenCloseGUIElement(inventoryChilds);
        }
        if(Input.GetKeyDown(KeyCode.J)) {
            OpenCloseGUIElement(questJournalChilds);
        }
        // if we player is ready to interact (watch DialogueTrigger class)and get E key
        // invoke StartConversation event
        if (Input.GetKeyDown(KeyCode.E) && readyToInteract == true) {
            EventManager.TriggerEvent(EventName.StartConversation);
        }
    }

    /// <summary>
    /// Open/close active/noactive GUI element
    /// </summary>
    /// <param name="childs"></param>
    private void OpenCloseGUIElement(List<GameObject> childs) {

        UnityExtensions.SetActiveGameObjectChilds(childs);
        StatusUtils.GUIisActive = !false;
    }
    /// <summary>
    /// Open/close dialogue window if StartConversation event invoked
    /// </summary>
    /// <param name="arg"></param>
    private void StartOrExitConversationEvent(EventArg arg) {
        OpenCloseGUIElement(dialogueWindowChilds);
    }

    /// <summary>
    /// Set ready to interact if event invoked
    /// </summary>
    /// <param name="arg"></param>
    private void ReadyToInteractEvent(EventArg arg) {
        readyToInteract = arg.FirstBoolArg;
    }
    /// <summary>
    /// Close quest journal event for close button
    /// </summary>
    private void CloseQuestJournalEvent(EventArg arg) {
        OpenCloseGUIElement(questJournalChilds);
    }
}
