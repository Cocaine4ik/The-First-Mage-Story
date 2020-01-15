using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavensSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject ravensPrefab;
    [SerializeField] private GameObject canvas;

    // ravnesPrefab colider component
    private BoxCollider2D boxCollider2D;

    private float ravensPrefabWidth;
    private float ravensPrefabHeight;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening(EventName.SpawnRavens, OnSpawnRavens);

        GameObject tempRavens = Instantiate(ravensPrefab);

        boxCollider2D = tempRavens.GetComponent<BoxCollider2D>();

        ravensPrefabWidth = boxCollider2D.size.x;
        ravensPrefabHeight = boxCollider2D.size.y;

        Destroy(tempRavens);

        SpawnRavens();

    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.SpawnRavens, OnSpawnRavens);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnRavens() {

        Debug.Log(ravensPrefabWidth);

        GameObject ravens = Instantiate(ravensPrefab, canvas.transform);
        Vector2 spawnPos = new Vector2(Screen.width/2 + ravensPrefabWidth , -Screen.height/2);
        ravens.transform.localPosition = spawnPos;
    }

    #endregion

    #region Events

    public void OnSpawnRavens(EventArg arg) {

        SpawnRavens();

    }

    #endregion
}
