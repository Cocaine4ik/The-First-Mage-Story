﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

/// <summary>
/// Main GUI class to control and manage player interface
/// </summary>
public class GUIController : MonoBehaviour {

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject questJournal;
    [SerializeField] private GameObject characterMenu;
    [SerializeField] private GameObject spellbook;

    private List<List<GameObject>> allChildsList = new List<List<GameObject>>();
    private List<GameObject> inventoryChilds;
    private List<GameObject> questJournalChilds;
    private List<GameObject> characterMenuChilds;
    private List<GameObject> spellbookChilds;

    private bool readyToInteract = false;

    private void OnEnable() {

        EventManager.StartListening(EventName.ReadyToInteract, ReadyToInteractEvent);
        EventManager.StartListening(EventName.CloseQuestJournal, CloseQuestJournalEvent);

    }
    private void OnDisable() {

        EventManager.StopListening(EventName.ReadyToInteract, ReadyToInteractEvent);
        EventManager.StopListening(EventName.CloseQuestJournal, CloseQuestJournalEvent);

    }

    private void Start() {

        allChildsList.Add(inventoryChilds = UnityExtensions.CreateChildsList(inventory.transform));
        allChildsList.Add(questJournalChilds = UnityExtensions.CreateChildsList(questJournal.transform));
        allChildsList.Add(characterMenuChilds = UnityExtensions.CreateChildsList(characterMenu.transform));
        allChildsList.Add(spellbookChilds = UnityExtensions.CreateChildsList(spellbook.transform));
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
            questJournal.GetComponentInParent<QuestJournal>().PanelRectTransform.SetAsLastSibling();
        }

        if (Input.GetKeyDown(KeyCode.C) && StatusUtils.DialogueIsActive == false) {
            EventManager.TriggerEvent(EventName.RefreshCharacterMenuValues);
            EventManager.TriggerEvent(EventName.SaveCharacterMenuCash);
            OpenCloseGUIElement(characterMenuChilds);
            characterMenu.GetComponent<CharacterMenu>().PanelRectTransform.SetAsLastSibling();
        }

        if(Input.GetKeyDown(KeyCode.B) && StatusUtils.DialogueIsActive == false) {
            EventManager.TriggerEvent(EventName.RefreshSpellBook);
            OpenCloseGUIElement(spellbookChilds);
            spellbook.GetComponent<SpellBook>().PanelRectTransform.SetAsLastSibling();
        }

        // if we player is ready to interact (watch DialogueTrigger class)and get E key
        // DialogueSystem.Instance.StartConversation()
        if (Input.GetKeyDown(KeyCode.E) && VD.assigned != null) {
            DialogueSystem.Instance.Interact(VD.assigned);
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
