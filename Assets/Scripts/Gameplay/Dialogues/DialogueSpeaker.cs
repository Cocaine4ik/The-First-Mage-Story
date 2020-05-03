using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialogue speaker class
/// icnludes getters for dialogue portraits and speakers name
/// + speaker names localization
/// </summary>
/// 
public class DialogueSpeaker : MonoBehaviour
{
    [SerializeField] private string speakerLocalizationKey;
    [SerializeField] private Image speakerPortrait;

    private string dialogueSpeakerName;

    public string DialogueSpeakerName => dialogueSpeakerName;
    public Image SpeakerPortait => speakerPortrait; 

    private void Start() {

        // dialogueSpeakerName = LocalizationManager.Localize(speakerLocalizationKey);

    }
}
