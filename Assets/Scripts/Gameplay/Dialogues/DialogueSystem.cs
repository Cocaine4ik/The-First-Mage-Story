using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DialogueSystem : Singleton<DialogueSystem>

{
    private DialogueWindow dialogueWindow;
    private DialogueParser dialogueParser;

    private QuestGiver questGiver;

    private bool isSetDialogue;

    private Sprite changedFormPortrait;
    private void Start()
    {
        dialogueWindow = GetComponent<DialogueWindow>();
        dialogueParser = GetComponent<DialogueParser>();
    }

    public void SetDialogueData(DialogueContainer dialogue, Sprite leftPortait, Sprite rightPortrait, string leftSpeakerKey, string rightSpeakerKey)
    {
        SetSpeakers(leftPortait, rightPortrait, leftSpeakerKey, rightSpeakerKey);
        dialogueParser.SetDialogue(dialogue);
        isSetDialogue = true;
    }
    public void SetDialogueData(DialogueContainer dialogue, Sprite leftPortait, string leftSpeakerKey)
    {
        SetSpeakers(leftPortait, leftPortait, leftSpeakerKey, leftSpeakerKey);
        dialogueParser.SetDialogue(dialogue);
        isSetDialogue = true;
    }
    public void StartConversation()
    {
        if(isSetDialogue)
        {
            var dialogueData = dialogueParser.Dialogue.NodeLinks.First();
            dialogueParser.ProceedToDialogue(dialogueData.TargetNodeGUID);
        }
        EventManager.TriggerEvent(EventName.StartConversation);
    }

    public void SetSpeakers(Sprite leftPortait, Sprite rightPortrait, string leftSpeakerKey, string rightSpeakerKey)
    {
        dialogueWindow.SetLeftSpeaker(leftPortait, leftSpeakerKey);
        dialogueWindow.SetRightSpeaker(rightPortrait, rightSpeakerKey);
    }

    public void ExitDialogue()
    {
        isSetDialogue = false;
        EventManager.TriggerEvent(EventName.ExitConversation, new EventArg(dialogueParser.Dialogue.name));
    }
    public void AddQuest()
    {
        if(questGiver != null) QuestSystem.Instance.AddQuest(questGiver.QuestName);

    }
    public void AddQuestAndExit()
    {
        ExitDialogue();
        AddQuest();
    }

    public void SetQuestData(QuestGiver questGiver)
    {
        this.questGiver = questGiver;
    }
    public void ChangeForm()
    {
        //dialogueWindow.SetLeftSpeaker(leftPortait, leftSpeakerKey);
    }
}
