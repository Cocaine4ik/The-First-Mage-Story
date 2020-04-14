using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main GUI class to control and manage player interface
/// </summary>
public class GUIController : MonoBehaviour {

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject dialogueWindow;

    private List<GameObject> inventoryChilds;
    private List<GameObject> dialogueWindowChilds;

    private bool readyToInteract = false;

    private void OnEnable() {

        EventManager.StartListening(EventName.StartConversation, StartOrExitConversationEvent);
        EventManager.StartListening(EventName.ExitConversation, StartOrExitConversationEvent);
        EventManager.StartListening(EventName.ReadyToInteract, ReadyToInteractEvent);

    }
    private void OnDisable() {

        EventManager.StopListening(EventName.StartConversation, StartOrExitConversationEvent);
        EventManager.StopListening(EventName.ExitConversation, StartOrExitConversationEvent);
        EventManager.StopListening(EventName.ReadyToInteract, ReadyToInteractEvent);

    }
    private void Start() {

        inventoryChilds = CreateChildsList(inventory.transform);
        dialogueWindowChilds = CreateChildsList(dialogueWindow.transform);

        OpenCloseGUIElement(inventoryChilds);
        OpenCloseGUIElement(dialogueWindowChilds);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {

            OpenCloseGUIElement(inventoryChilds);
        }
        // if we player is ready to interact (watch DialogueTrigger class)and get E key
        // invoke StartConversation event
        if (Input.GetKeyDown(KeyCode.E) && readyToInteract == true) {
            EventManager.TriggerEvent(EventName.StartConversation);
        }
    }
    /// <summary>
    /// Return transform object childs List
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    private List<GameObject> CreateChildsList(Transform parent) {

        List<GameObject> childsList = new List<GameObject>();

        foreach (Transform child in parent) {
            childsList.Add(child.gameObject);
        }
        return childsList;
    }

    /// <summary>
    /// Open/close active/noactive GUI element
    /// </summary>
    /// <param name="childs"></param>
    private void OpenCloseGUIElement(List<GameObject> childs) {

        if (childs != null) {
            foreach (GameObject gameObject in childs) {
                gameObject.SetActive(!gameObject.activeSelf);             
            }
        }
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
}
