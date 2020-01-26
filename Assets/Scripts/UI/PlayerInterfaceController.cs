using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private List<GameObject> inventoryChilds;

    private void Start() {

        foreach (Transform child in inventory.transform) {

            inventoryChilds.Add(child.gameObject);

        }

        OpenCloseInventory();
    }
    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.I)) {

            OpenCloseInventory();
        }
    }

    private void OpenCloseInventory() {

        if (inventoryChilds != null) {

            foreach (GameObject gameObject in inventoryChilds) {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }
}
