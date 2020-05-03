using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main GUI class to control and manage player interface
/// </summary>
public class GUIController : MonoBehaviour {

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject dialogueWindow;
    [SerializeField] private GameObject questJournal;

    private List<List<GameObject>> allChildsList = new List<List<GameObject>>();
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

        allChildsList.Add(inventoryChilds = UnityExtensions.CreateChildsList(inventory.transform));
        allChildsList.Add(dialogueWindowChilds = UnityExtensions.CreateChildsList(dialogueWindow.transform));
        allChildsList.Add(questJournalChilds = UnityExtensions.CreateChildsList(questJournal.transform));

        // Open/close inventory to initialize inventory cells

        for (int i = 0; i < 2; i++ ) {
            OpenCloseGUIElement(inventoryChilds);
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.I) && StatusUtils.DialogueIsActive == false) {

            OpenCloseGUIElement(inventoryChilds);
            inventory.GetComponent<Inventory>().PanelRectTransform.SetAsLastSibling();
        }
        if(Input.GetKeyDown(KeyCode.J) && StatusUtils.DialogueIsActive == false) {
            OpenCloseGUIElement(questJournalChilds);
            questJournal.GetComponent<QuestJournal>().PanelRectTransform.SetAsLastSibling();
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
        StatusUtils.GUIisActive = !StatusUtils.GUIisActive;
        Debug.Log("GUI is active: " + StatusUtils.GUIisActive);

        // check if other GUI menu elements is active - close them
        foreach (List<GameObject> childList in allChildsList) {

            if (childList != childs) {
                if (UnityExtensions.IsActiveChilds(childList) == true) {
                    UnityExtensions.SetActiveGameObjectChilds(childList);
                    StatusUtils.GUIisActive = !StatusUtils.GUIisActive;
                    Debug.Log("GUI is active: " + StatusUtils.GUIisActive);
                }
            }
        }
    }
    /// <summary>
    /// Open/close dialogue window if StartConversation event invoked
    /// </summary>
    /// <param name="arg"></param>
    private void StartOrExitConversationEvent(EventArg arg) {
        OpenCloseGUIElement(dialogueWindowChilds);
        dialogueWindow.GetComponent<DialogueParser>().PanelRectTransform.SetAsLastSibling();
        StatusUtils.DialogueIsActive = !StatusUtils.DialogueIsActive;
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
