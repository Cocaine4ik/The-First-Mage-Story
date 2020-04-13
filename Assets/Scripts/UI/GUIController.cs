using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour {

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject dialogueWindow;

    private List<GameObject> inventoryChilds;
    private List<GameObject> dialogueWindowChilds;

    private void OnEnable() {
        EventManager.StartListening(EventName.StartConversation, StartConversationEvent);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.StartConversation, StartConversationEvent);
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

        if (Input.GetKeyDown(KeyCode.E) && GetComponent<DialogueTrigger>().Interactable) {

            OpenCloseGUIElement(dialogueWindowChilds);
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

    private void StartConversationEvent(EventArg arg) {
        OpenCloseGUIElement(dialogueWindowChilds);
    }
}
