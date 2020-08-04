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
    [SerializeField] private SpeakerName speakerName;
    [SerializeField] private Sprite speakerPortrait;

    private string dialogueSpeakerName;

    public string DialogueSpeakerName => dialogueSpeakerName;
    public Sprite SpeakerPortait => speakerPortrait; 

    private void Start() {

        // dialogueSpeakerName = LocalizationManager.Localize(speakerLocalizationKey);

    }
}
