using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour {

    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private float spawnTime = 2f;

    private int currentPosIndex;

    // Start is called before the first frame update
    void Start() {

        currentPosIndex = 0;

        StartCoroutine(SpawnEfects(spawnTime, spawnPrefab, spawnPositions));
    }

    IEnumerator SpawnEfects(float spawnTime, GameObject spawnPrefab, List<Transform> spawnPositions) {

        yield return new WaitForSeconds(spawnTime);
        var spawnObject = Instantiate(spawnPrefab, spawnPositions[currentPosIndex]);
        spawnObject.transform.localRotation = spawnPositions[currentPosIndex].transform.localRotation;

        if (currentPosIndex != spawnPositions.Count -1) {
            currentPosIndex++;
        }
        else if (currentPosIndex == spawnPositions.Count - 1) {
            currentPosIndex = 0;
        }

        StartCoroutine(SpawnEfects(spawnTime, spawnPrefab, spawnPositions));
    }
}
