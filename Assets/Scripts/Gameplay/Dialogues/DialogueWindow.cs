using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VIDE_Data;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPC_Text;
    [SerializeField] private TextMeshProUGUI NPC_label;
    [SerializeField] private Image NPCSprite;
    [SerializeField] private GameObject playerChoicePrefab;
    [SerializeField] private Image playerSprite;
    [SerializeField] private TextMeshProUGUI playerLabel;

    //We'll be using this to store references of the current player choices
    private List<TextMeshProUGUI> currentChoices = new List<TextMeshProUGUI>();

    /*
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
    */
}
