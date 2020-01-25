using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject inventory;

    private void Update() {

        if (Input.GetKeyDown(KeyCode.I)) {
            inventory.SetActive(!inventory.gameObject.activeSelf);
        }

    }
}
