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

    public void SetLeftSpeaker(Sprite portrait, string speakerKey)
    {
        leftSpeakerPortrait.sprite = portrait;
        leftSpeakerLocalization.ChangeLocalization(speakerKey);
    }
    public void SetRightSpeaker(Sprite portrait, string speakerKey)
    {
        rightSpeakerPortrait.sprite = portrait;
        rightSpeakerLocalization.ChangeLocalization(speakerKey);
    }

}
