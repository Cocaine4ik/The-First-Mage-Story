using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawner : UIElementBase {

    [SerializeField] private Transform parent;

    public void OnSpawn() {
        
            GameObject spawnObject = Instantiate(gameObject, parent);
            spawnObject.transform.position = new Vector2((float)Random.Range(-Screen.width, Screen.width),
                (float)Random.Range(-Screen.height, Screen.height));

    }
}
