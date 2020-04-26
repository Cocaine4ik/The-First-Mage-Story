using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tipsPrefab;
    [SerializeField] private bool isTrigger = true;

    private Transform canvas;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Player>() != null && isTrigger == true) {
            SpawnTip();
        }
    }
    private void Start() {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        if (isTrigger == false) {
            EventManager.StartListening(EventName.ExitConversation, OnSpawnTip);
        }
    }

    private void OnDestroy() {
        if (!isTrigger) {
            EventManager.StopListening(EventName.ExitConversation, OnSpawnTip);
        }
    }

    private void OnSpawnTip(EventArg arg) {
        if(arg.FirstStringArg == GetComponent<DialogueTrigger>().Dialogue.name) {
            SpawnTip();
        }
    }

    private void SpawnTip() {
        Debug.Log("SpawnTip: " + tipsPrefab.name);
        Instantiate(tipsPrefab, canvas);
        Destroy(gameObject);
    }
}
