using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.Remoting.Messaging;

[System.Serializable]
public class Inventory : UIElementBase {

    #region Fields
    [Header("Inventory components")]
    [SerializeField] private int inventorySize;

    [SerializeField] private List<InventoryCell> inventoryCells;
    [SerializeField] private InventoryCell inventoryCellTemplate;
    [SerializeField] private Transform storage;

    [Header("Localization components")]
    [SerializeField] private LocalizedTMPro itemName;
    [SerializeField] private LocalizedTMPro itemDescription;
    [SerializeField] private LocalizedTMPro itemType;

    private const string ItemNameKey = "Items.Name.";
    private const string ItemDescriptionKey = "Items.Description.";
    private const string ItemTypeKey = "Items.Type.";

    #endregion

    #region Methods

    private void OnEnable() {
           AddInventoryCells();
    }

    protected override void Start() {
        base.Start();
        EventManager.StartListening(EventName.ShowInventoryItemData, OnSetSelectedItemData);
        EventManager.StartListening(EventName.ChangeItemTypeColor, OnChangeItemTypeColor);
    }
    private void OnDestroy() {
        EventManager.StopListening(EventName.ShowInventoryItemData, OnSetSelectedItemData);
        EventManager.StopListening(EventName.ChangeItemTypeColor, OnChangeItemTypeColor);
    }

    public void AddItemToInventory(Item item)
    {
        foreach (InventoryCell cell in inventoryCells)
        {
            // Increase stack item number value
            if (!cell.IsEmpty && item.ItemName == cell.ItemName)
            {
                cell.AddItemToStack(item.ItemNumber);
                break;
            }
            // add item to Inventory Cell
            else if (cell.IsEmpty)
            {
                cell.AddItemToCell(item);
                Debug.Log("AddItem: " + item.name);
                break;
            }
        }
    }
    private void AddInventoryCells() {

        for (int i = 0; i < inventorySize; i++) {

            var cell = Instantiate(inventoryCellTemplate, storage);
            cell.SetId(i);
            inventoryCells.Add(cell);

        }
    }

    private void OnSetSelectedItemData(EventArg arg) {

        itemName.ChangeLocalization(ItemNameKey + arg.ItemName.ToString());
        itemDescription.ChangeLocalization(ItemDescriptionKey + arg.ItemName.ToString());
        itemType.ChangeLocalization(ItemTypeKey + arg.ItemType.ToString());
    }

    private void OnChangeItemTypeColor(EventArg arg) {

        itemType.gameObject.GetComponent<TextMeshProUGUI>().color = arg.Color;
    }
    #endregion
}
