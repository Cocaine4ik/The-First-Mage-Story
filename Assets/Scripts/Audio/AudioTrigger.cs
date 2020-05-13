using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {
    [SerializeField] private AudioClipName clipName;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Player>() != null || collision.gameObject.name == "Archmage") {
            AudioManager.Play(clipName);
        }
    }
}
