using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadConversation : SaveLoadData
{
    private DialogueTrigger dialogueTrigger;
    private SpeechTrigger speechTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        speechTrigger = GetComponent<SpeechTrigger>();
    }
    protected override void OnLoadData(EventArg arg)
    {
        var destroFlag = PlayerPrefs.GetInt(gameObject.name).GetBoolFromInt();

    }

    protected override void OnSaveData(EventArg arg)
    {
        SaveDialogueTrigger();
    }

    private void SaveDialogueTrigger()
    {
        if(dialogueTrigger != null)
        {
            PlayerPrefs.SetInt(gameObject.name, dialogueTrigger.IsDone.SetBoolToInt());
        }

    }

    private void SaveSpeechTrigger()
    {

    }

    private void LoadDialogueTrigger(bool flag)
    {
        if (dialogueTrigger != null)
        {
            if (flag == true) Destroy(gameObject);
        }

    }

    private void LoadSpeechTrigger()
    {

    }
}
