using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValleyOfTheWinds : MonoBehaviour
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
        StartCoroutine(StartArachmageMovement(timeBeforeAchmageMove));
    }

    private void Update() {
        
        if(spiritSpeechTrigger.SpeechIsEnd == true && spiritHealth != null) {
            spiritHealth.TakeDamage(10);
            StartCoroutine(GoToNextScene("MagicCliffs"));
        }
    }

    private IEnumerator StartArachmageMovement(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        mageBehaviour.enabled = true;
    }

    private IEnumerator GoToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }
}
