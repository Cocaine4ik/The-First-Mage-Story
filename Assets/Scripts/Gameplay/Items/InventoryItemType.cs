using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemType : MonoBehaviour
{
    private void Start() {

        EventManager.StartListening(EventName.ShowInventoryItemType, OnChangedTypeKey);
    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.ShowInventoryItemType, OnChangedTypeKey);

    }
    public void OnChangedTypeKey(EventArg arg) {

        GetComponent<LocalizedTMPro>().ChangeLocalization(arg.FirstStringArg);
    }
}
