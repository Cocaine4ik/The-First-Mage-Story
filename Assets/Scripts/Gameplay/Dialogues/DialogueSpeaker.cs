using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private const string speakersKey = "Speakers.";

    public string SpeakerNameKey => speakersKey + speakerName.ToString();
    public Sprite SpeakerPortait => speakerPortrait; 
}
