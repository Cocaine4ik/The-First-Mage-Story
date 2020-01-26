using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemName : MonoBehaviour
{
    private void Start() {

        EventManager.StartListening(EventName.ShowInventoryName, OnChangedNameKey);
    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.ShowInventoryName, OnChangedNameKey);

    }
    public void OnChangedNameKey(EventArg arg) {

        GetComponent<LocalizedTMPro>().ChangeLocalizationKey(arg.FirstStringArg);
        GetComponent<LocalizedTMPro>().ChangeLocalization();
    }
}
