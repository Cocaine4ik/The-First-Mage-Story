using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsSpawner : MonoBehaviour
{
    [SerializeField] private int id;
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
            EventManager.StartListening(EventName.SpawnTip, OnSpawnTip);
        }
    }

    private void OnSpawnTip(EventArg arg) {
        
        if(arg.FirstIntArg == id) {
            SpawnTip();
        }
    }

    private void SpawnTip() {
        Debug.Log("SpawnTip: " + tipsPrefab.name);
        
       GameObject[] oldTips = GameObject.FindGameObjectsWithTag("Tip");
        if (oldTips.Length > 0)
        {
            foreach (GameObject tip in oldTips)
            {
                Destroy(tip);
            }
        }
        Instantiate(tipsPrefab, canvas);
        Destroy(gameObject);
    }
}
