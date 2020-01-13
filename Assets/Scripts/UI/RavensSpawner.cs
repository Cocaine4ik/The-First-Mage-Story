using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavensSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ravensPrefab;
    [SerializeField] private GameObject canvas;
    private Ravens ravens;


    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening(EventName.SpawnRavens, OnSpawnRavens);
        ravens = ravensPrefab.GetComponent<Ravens>();
        SpawnRavens();

    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.SpawnRavens, OnSpawnRavens);

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(ravens.ColliderWidth);
    }

    private void SpawnRavens() {

        Debug.Log(ravens.ColliderWidth);
        GameObject birds = Instantiate(ravensPrefab, canvas.transform);
        Vector2 spawnPos = new Vector2(Screen.width/2 + ravens.ColliderWidth, -Screen.height/2);
        birds.transform.localPosition = spawnPos;
    }

    public void OnSpawnRavens(EventArg arg) {

        SpawnRavens();

    }
    
}
