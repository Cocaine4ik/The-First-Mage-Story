using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemDescription : MonoBehaviour
{
    private void Start() {

        EventManager.StartListening(EventName.ShowInventoryItemDescription, OnChangedNameKey);
    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.ShowInventoryItemDescription, OnChangedNameKey);

    }
    public void OnChangedNameKey(EventArg arg) {

        GetComponent<LocalizedTMPro>().ChangeLocalization(arg.FirstStringArg);
    }
}
