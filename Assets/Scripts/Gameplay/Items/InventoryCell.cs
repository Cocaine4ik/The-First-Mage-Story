using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCell : MonoBehaviour
{
    private Image iconField;
    private string itemNameKey;
    private string itemTypeKey;
    private string itemDescriptionKey;
    private int itemNumber;

    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private int id;
    [SerializeField] private bool isEmpty;
    [SerializeField] private bool isStack;

    public bool IsEmpty => isEmpty;
    public bool IsStack => isStack;
    public string ItemNameKey => itemNameKey;

    private void Awake() {

        isEmpty = true;
        itemNumber = 0;
        isStack = false;
        iconField = GetComponent<Image>();
    }

    public void SetId(int id) {

        this.id = id;
    }

    public void AddItemToCell(IITem item) {

        iconField.sprite = item.ItemIcon;
        itemNameKey = item.ItemNameKey;
        itemTypeKey = item.ItemTypeKey;
        itemDescriptionKey = item.ItemDescriptionKey;
        isEmpty = false;
    }

    public void OnInventoryCellSelected() {

        if (isEmpty == false) {
            EventManager.TriggerEvent(EventName.ShowInventoryItemData, new EventArg(itemNameKey, itemDescriptionKey, itemTypeKey));
        }

    }
    public void AddItemToStack() {
        if(isStack == false) {

        }
        itemNumber += 1;
        
    }
}
