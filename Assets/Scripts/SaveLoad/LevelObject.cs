using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelObject : MonoBehaviour
{
    #region Fields
    private float[] position;
    private GameObject prefab;

    #endregion

    #region Methods

    private void Start() {

        prefab = gameObject;
        position = new float[3];
        position[0] = gameObject.transform.position.x;
        position[1] = gameObject.transform.position.y;
        position[2] = gameObject.transform.position.z;

    }

    #endregion
}
