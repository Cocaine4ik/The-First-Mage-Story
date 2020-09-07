using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : Singleton<DialogueSystem>
{
    private DialogueWindow dialogueWindow;
    private DialogueParser dialogueParser;

    private void Start()
    {
        dialogueWindow = GetComponent<DialogueWindow>();
        dialogueParser = GetComponent<DialogueParser>();
    }



}
