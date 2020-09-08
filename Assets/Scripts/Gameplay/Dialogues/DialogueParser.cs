using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

/// <summary>
/// 
/// </summary>
public class DialogueParser : UIElementBase
{
    private DialogueContainer dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button choicePrefab;
    [SerializeField] private Transform buttonContainer;

    private QuestName questName;
    private DialogueWindow

    public DialogueContainer Dialogue => dialogue;

    public void ProceedToDialogue(string dialogueDataGUID) {

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
            /*
            exposedProperty.Localize();
            LocalizationManager.LocalizationChanged += exposedProperty.Localize;
            */
            text = text.Replace($"[{exposedProperty.PropertyName}]", exposedProperty.PropertyValue);

        }
        return text;
    }

    private void AddOnClickEvents(string text, Button button, NodeLinkData choice) {

        var propertyName = GetProperty(text);
        Debug.Log(propertyName.ToString());
        switch(propertyName)
        {
            case PropertyName.AddQuestAndExit: button.onClick.AddListener(() => AddQuestAndExit()); break;
            case PropertyName.AddQuest: button.onClick.AddListener(() => AddQuest()); break;
            case PropertyName.ChangeSpeaker: break;
            case PropertyName.Atack: break;
            case PropertyName.CompleteTask: break;
            case PropertyName.Exit: button.onClick.AddListener(() => ExitDialogue()); break;
            default: button.onClick.AddListener(() => ProceedToDialogue(choice.TargetNodeGUID)); break;
        }       
    }

    private PropertyName GetProperty(string text)
    {
        foreach (PropertyName property in Enum.GetValues(typeof(PropertyName)))
        {
            bool isProperty = text.IndexOf(property.ToString()) != -1 ? true : false;
            if (isProperty) return property;
        }
        return PropertyName.Proceed;
    }
    private void ExitDialogue() {

            EventManager.TriggerEvent(EventName.ExitConversation, new EventArg(dialogue.name));
    }
    private void AddQuest() {

        QuestSystem.Instance.AddQuest(questName);
    }
    private void AddQuestAndExit()
    {
        Debug.Log(dialogue.name);
        ExitDialogue();
        AddQuest();
    }

    private void ChangeSpeaker()
    {
       // EventManager.TriggerEvent(EventName.SetLeftSpeakerPortrait())
    }

    private void OnDestroy() {
        /*
        if(dialogue != null) {

            foreach (var exposedProperty in dialogue.ExposedProperties) {
                LocalizationManager.LocalizationChanged -= exposedProperty.Localize;
            }
        }
        */
    }

    public void SetQuest(QuestName questName)
    {
        this.questName = questName;
    }

}
