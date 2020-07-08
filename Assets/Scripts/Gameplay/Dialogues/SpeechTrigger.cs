using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechTrigger : TalkTrigger
{
    [Header("Speech Buble Options:")]
    [SerializeField] GameObject speechBubble;
    [SerializeField] private float bubbleLifetime = 2f;
    [SerializeField] private List<string> speechKeys;
    [SerializeField] private bool isRepeating = true;

    private int currentSpeechKeyIndex = 0;
    private LocalizedTMPro speechLocalization;
    private bool speechIsEnd = false;

    public bool SpeechIsEnd => speechIsEnd;


    // Start is called before the first frame update
    void Start() {

        speechLocalization = speechBubble.GetComponentInChildren<LocalizedTMPro>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (isInteractable == false) {

            if (collision.GetComponentInChildren<Character>() != null)
            StartConversation();
        }

    }
    private IEnumerator DeactivateBubble(float bubleLifetime) {

        yield return new  WaitForSeconds(bubleLifetime);
        speechBubble.SetActive(false);

        if (currentSpeechKeyIndex != speechKeys.Count - 1) {
            currentSpeechKeyIndex++;
        }
        else if (currentSpeechKeyIndex == speechKeys.Count - 1) {

            currentSpeechKeyIndex = 0;
            if (isRepeating == false) {
                speechIsEnd = true;
            }
        }
        if (speechIsEnd == false) {
            StartConversation();
        }

    }
    protected override void StartConversation() {

        speechBubble.SetActive(true);
        speechLocalization.ChangeLocalization(speechKeys[currentSpeechKeyIndex]);

        StartCoroutine(DeactivateBubble(bubbleLifetime));      
    }

    protected override IEnumerator StartScriptableConversation(float scriptableTime) {
        throw new System.NotImplementedException();
    }

}
