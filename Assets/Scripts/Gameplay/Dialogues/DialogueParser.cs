﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

/// <summary>
/// 
/// </summary>
public class DialogueParser : UIElementBase
{
    [SerializeField] private DialogueContainer dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button choicePrefab;
    [SerializeField] private Transform buttonContainer;

    private QuestName questName;

    private void OnEnable() {
        EventManager.StartListening(EventName.StartConversation, StartConversationEvent);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.StartConversation, StartConversationEvent);
    }

    private void ProceedToDialogue(string dialogueDataGUID) {

        var text = dialogue.DialogueNodeData.Find(x => x.NodeGUID == dialogueDataGUID).DialogueText;
        var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGUID == dialogueDataGUID);
        dialogueText.text = ProcessProperties(text);
        var buttons = buttonContainer.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++) {
            Destroy(buttons[i].gameObject);
        }
        foreach (var choice in choices) {

            var button = Instantiate(choicePrefab, buttonContainer);
            AddOnClickEvents(choice.PortName, button, choice);

            button.GetComponentInChildren<TextMeshProUGUI>().text = ProcessProperties(choice.PortName);
        }
    }

    private string ProcessProperties(string text) {

        foreach (var exposedProperty in dialogue.ExposedProperties) {

            exposedProperty.Localize();
            LocalizationManager.LocalizationChanged += exposedProperty.Localize;

            text = text.Replace($"[{exposedProperty.PropertyName}]", exposedProperty.PropertyValue);

        }
        return text;
    }

    private void AddOnClickEvents(string text, Button button, NodeLinkData choice) {

        bool isExit = text.IndexOf("Exit") != -1 ? true : false;
        bool isAddQuestAndExit = text.IndexOf("AddQuestAndExit ") != -1 ? true : false;
        bool isAddQuest = text.IndexOf("AddQuest") != -1 ? true : false;

        if (isExit) button.onClick.AddListener(() => ExitDialogue());
        if (isAddQuestAndExit) button.onClick.AddListener(() => AddQuestAndExit());
        if (isAddQuest) button.onClick.AddListener(() => AddQuest());
        else {
            button.onClick.AddListener(() => ProceedToDialogue(choice.TargetNodeGUID));
        }
    }

    private void ExitDialogue() {

            EventManager.TriggerEvent(EventName.ExitConversation, new EventArg(dialogue.name));
    }
    private void AddQuest() {

        QuestSystem.Instance.AddQuest(questName);
    }
    private void AddQuestAndExit()
    {
        ExitDialogue();
        AddQuest();
    }

    private void OnDestroy() {

        if(dialogue != null) {

            foreach (var exposedProperty in dialogue.ExposedProperties) {
                LocalizationManager.LocalizationChanged -= exposedProperty.Localize;
            }
        }

    }
    private void StartConversationEvent(EventArg arg) {

        if (dialogue != null) {
            var dialogueData = dialogue.NodeLinks.First();
            ProceedToDialogue(dialogueData.TargetNodeGUID);
        }
    }
    /// <summary>
    /// Set dialogue data
    /// </summary>
    /// <param name="dialogue"></param>
    public void SetDialogue(DialogueContainer dialogue) {

        this.dialogue = dialogue;
    }

    public void SetQuest(QuestName questName)
    {
        this.questName = questName;
    }

}
