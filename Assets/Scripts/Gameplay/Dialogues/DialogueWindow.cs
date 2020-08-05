using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private Image leftSpeakerPortrait;
    [SerializeField] private Image rightSpeakerPortrait;
    [SerializeField] private LocalizedTMPro leftSpeakerLocalization;
    [SerializeField] private LocalizedTMPro rightSpeakerLocalization;
    private void OnEnable()
    {
        EventManager.StartListening(EventName.SetLeftSpeakerPortrait, OnSetLeftSpeakerPortrait);
        EventManager.StartListening(EventName.SetLeftSpeakerNameKey, OnSetLeftSpeakerNameKey);
        EventManager.StartListening(EventName.SetRightSpeakerPortrait, OnSetRightSpeakerPortrait);
        EventManager.StartListening(EventName.SetRightSpeakerNameKey, OnSetRightSpeakerNameKey);
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventName.SetLeftSpeakerPortrait, OnSetLeftSpeakerPortrait);
        EventManager.StopListening(EventName.SetLeftSpeakerNameKey, OnSetLeftSpeakerNameKey);
        EventManager.StopListening(EventName.SetRightSpeakerPortrait, OnSetRightSpeakerPortrait);
        EventManager.StopListening(EventName.SetRightSpeakerNameKey, OnSetRightSpeakerNameKey);
    }

    private void OnSetLeftSpeakerPortrait(EventArg arg)
    {
        leftSpeakerPortrait.sprite = arg.Sprite;
    }
    private void OnSetRightSpeakerPortrait(EventArg arg)
    {
        rightSpeakerPortrait.sprite = arg.Sprite;
    }
    private void OnSetLeftSpeakerNameKey(EventArg arg)
    {
        leftSpeakerLocalization.ChangeLocalization(arg.FirstStringArg);
    }
    private void OnSetRightSpeakerNameKey(EventArg arg)
    {
        rightSpeakerLocalization.ChangeLocalization(arg.FirstStringArg);
    }
}
