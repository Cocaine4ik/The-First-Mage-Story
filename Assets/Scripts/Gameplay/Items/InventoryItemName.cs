using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemName : MonoBehaviour
{
    private void Start() {

        EventManager.StartListening(EventName.ShowInventoryItemName, OnChangedNameKey);
    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.ShowInventoryItemName, OnChangedNameKey);

    }
    public void OnChangedNameKey(EventArg arg) {

        GetComponent<LocalizedTMPro>().ChangeLocalization(arg.FirstStringArg);
    }
}
