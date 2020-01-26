using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    private Image iconField;
    private string itemNameKey;
    private string itemTypeKey;

    [SerializeField] private int id;
    [SerializeField] private bool isEmpty;
    [SerializeField] private bool isFull;

    public bool IsEmpty => isEmpty;

    private void Awake() {

        iconField = GetComponent<Image>();
        isEmpty = true;
        isFull = false;
    }

    public void SetId(int id) {

        this.id = id;
    }

    public void AddItemToCell(IITem item) {

        iconField.sprite = item.ItemIcon;
        itemNameKey = item.ItemNameKey;
        itemTypeKey = item.ItemTypeKey;
        isFull = true;
    }

    public void OnInventoryCellSelected() {

        if (isFull == true) {
            EventManager.TriggerEvent(EventName.ShowInventoryName, new EventArg(itemNameKey));
        }

    }

}
