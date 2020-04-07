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

    private void Start() {

        var dialogueData = dialogue.NodeLinks.First();
        ProceedToDialogue(dialogueData.TargetNodeGUID);

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
            if(choice.PortName != "Continue") {
            button.onClick.AddListener(() => ProceedToDialogue(choice.TargetNodeGUID));
            }
            else {
                button.onClick.AddListener(() => ExitDialogue());
            }
        }
    }

    private void ExitDialogue() {
        Destroy(this.gameObject);

    }
}
