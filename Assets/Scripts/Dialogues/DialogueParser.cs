using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogueParser : MonoBehaviour
{
    [SerializeField] private DialogueContainer dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button choicePrefab;
    [SerializeField] private Transform buttonContainer;

    private void OnEnable() {
        EventManager.StartListening(EventName.StartConversation, StartConversationEvent);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.StartConversation, StartConversationEvent);
    }

    private void ProceedToDialogue(string dialogueDataGUID) {

        var text = dialogue.DialogueNodeData.Find(x => x.NodeGUID == dialogueDataGUID).DialogueText;
        //Debug.Log(text);
        var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGUID == dialogueDataGUID);
        dialogueText.text = text;
        var buttons = buttonContainer.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++) {
            Destroy(buttons[i].gameObject);
        }
        foreach (var choice in choices) {
            var button = Instantiate(choicePrefab, buttonContainer);
            button.GetComponentInChildren<TextMeshProUGUI>().text = choice.PortName;

            if (choice.PortName == "Continue" || choice.PortName == "Продолжить") {
                button.onClick.AddListener(() => ExitDialogue());
            }

            else { 
                button.onClick.AddListener(() => ProceedToDialogue(choice.TargetNodeGUID));
            }
        }
    }

    private void ExitDialogue() {

        EventManager.TriggerEvent(EventName.ExitConversation);

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

}
