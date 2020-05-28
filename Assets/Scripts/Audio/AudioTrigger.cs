using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    [SerializeField] private GameObject triggerObject;
    [SerializeField] private bool onEnterOnly;
    [SerializeField] private bool playOneShot;

    private AudioSource audioSource;

    private void Start() {

        audioSource = GetComponent<AudioSource>();

        if(playOneShot == true) {
            audioSource.loop = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject + " " + triggerObject);
        if (collision.gameObject.name == triggerObject.name) {
            audioSource.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == triggerObject.name && onEnterOnly == false) {
            audioSource.Stop();
        }
    }
}
