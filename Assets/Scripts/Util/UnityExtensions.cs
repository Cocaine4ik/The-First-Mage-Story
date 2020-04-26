using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtensions
{

    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer) {

        return mask == (mask | (1 << layer));

    }

    public static float[] BubleSort(this float[] array) {

        for (int i = 0; i < array.Length; i++) {

            for (int j = 0; j < array.Length - 1; j++) {

                if (array[j] > array[j + 1]) {

                    float z = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = z;
                }
            }
        }
        return array;
    }
    /// <summary>
    /// Set active true/false game object childs
    /// </summary>
    /// <param name="childs"></param>
    public static void SetActiveGameObjectChilds(List<GameObject> childs) {

        if (childs != null) {
            foreach (GameObject gameObject in childs) {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }
    /// <summary>
    /// Return true if 
    /// </summary>
    /// <param name="childs"></param>
    /// <returns></returns>
    public static bool IsActiveChilds(List<GameObject> childs) {

        if (childs != null) {
            foreach (GameObject gameObject in childs) {
                if (gameObject.activeSelf == false) {
                    return false;
                }
            }
            return true;
        }
        Debug.Log("Error. No childs.");
        return false;
    }
    /// <summary>
    /// Return transform object childs List
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static List<GameObject> CreateChildsList(Transform parent) {

        List<GameObject> childsList = new List<GameObject>();

        foreach (Transform child in parent) {
            childsList.Add(child.gameObject);
        }
        return childsList;
    }
}
