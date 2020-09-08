using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using UnityEngine;

public class DialogueSystem : Singleton<DialogueSystem>
=======
using System.Linq;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
>>>>>>> Stashed changes
{
    private DialogueWindow dialogueWindow;
    private DialogueParser dialogueParser;

<<<<<<< Updated upstream
    private void Start()
    {
        dialogueWindow = GetComponent<DialogueWindow>();
        dialogueParser = GetComponent<DialogueParser>();
    }



=======
    // Start is called before the first frame update
    void Start()
    {
        dialogueWindow = GetComponent<DialogueWindow>();
        dialogueParser = GetComponent<DialogueParser>();
        
    }

    public void StartConversation(DialogueContainer dialogue, Sprite leftPortait, Sprite rightPortrait, string leftSpeakerKey, string rightSpeakerKey)
    {
        SetSpeakers(leftPortait, rightPortrait, leftSpeakerKey, rightSpeakerKey);
        dialogueParser.SetDialogue(dialogue);
        if(dialogueParser.Dialogue != null)
        {
            var dialogueData = dialogueParser.Dialogue.NodeLinks.First();
            dialogueParser.ProceedToDialogue(dialogueData.TargetNodeGUID);
        }
        EventManager.TriggerEvent(EventName.StartConversation);
    }

    public void StartScriptableConversation(DialogueContainer dialogue, Sprite leftPortait, Sprite rightPortrait, string leftSpeakerKey, string rightSpeakerKey)
    {
        StartConversation(dialogue, leftPortait, rightPortrait, leftSpeakerKey, rightSpeakerKey);
    }

    public void SetSpeakers(Sprite leftPortait, Sprite rightPortrait, string leftSpeakerKey, string rightSpeakerKey)
    {
        dialogueWindow.SetLeftSpeaker(leftPortait, leftSpeakerKey);
        dialogueWindow.SetRightSpeaker(rightPortrait, rightSpeakerKey);
    }
>>>>>>> Stashed changes
}
