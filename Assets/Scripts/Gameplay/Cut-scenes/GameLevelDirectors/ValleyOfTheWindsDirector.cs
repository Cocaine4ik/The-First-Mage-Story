using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValleyOfTheWindsDirector : SceneDirector
{
    [SerializeField] private GameObject spirit;
    [SerializeField] private GameObject archmage;
    [SerializeField] private float timeBeforeAchmageMove = 2f;

    private SpeechTrigger spiritSpeechTrigger;
    private CharacterHealth spiritHealth;

    private MageBehaviour mageBehaviour;

    private void Start() {

        spiritSpeechTrigger = spirit.GetComponent<SpeechTrigger>();
        spiritHealth = spirit.GetComponent<CharacterHealth>();
        mageBehaviour = archmage.GetComponent<MageBehaviour>();
        mageBehaviour.enabled = false;
        StartCoroutine(StartArchmageMovement(timeBeforeAchmageMove));
    }

    private void Update() {
        
        if(spiritSpeechTrigger.SpeechIsEnd == true && spiritHealth != null) {
            spiritHealth.TakeDamage(10, DamageType.None);
            StartCoroutine(GoToNextScene(SceneName.MagicCliffs));
        }
    }

    private IEnumerator StartArchmageMovement(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        mageBehaviour.enabled = true;
    }
}
