﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[System.Serializable]
public class Inventory : UIElementBase {

    #region Fields
    [SerializeField] private int inventorySize;

    [SerializeField] private List<Item> items;
    [SerializeField] private List<InventoryCell> inventoryCells;
    [SerializeField] private InventoryCell inventoryCellTemplate;
    [SerializeField] private Transform storage;

    [SerializeField] private LocalizedTMPro itemName;
    [SerializeField] private LocalizedTMPro itemDescription;
    [SerializeField] private LocalizedTMPro itemType;


    #endregion

    #region Methods

    private void OnEnable() {
           AddInventoryCells();
    }

    protected override void Start() {
        base.Start();
        EventManager.StartListening(EventName.PickupItem, AddItem);
        EventManager.StartListening(EventName.ShowInventoryItemData, OnSetSelectedItemData);
        EventManager.StartListening(EventName.ChangeItemTypeColor, OnChangeItemTypeColor);
    }
    private void OnDestroy() {
        EventManager.StopListening(EventName.PickupItem, AddItem);
        EventManager.StopListening(EventName.ShowInventoryItemData, OnSetSelectedItemData);
        EventManager.StopListening(EventName.ChangeItemTypeColor, OnChangeItemTypeColor);
    }

    private void AddInventoryCells() {

        for (int i = 0; i < inventorySize; i++) {

            var cell = Instantiate(inventoryCellTemplate, storage);
            cell.SetId(i);
            inventoryCells.Add(cell);

        }
    }

    public void AddItem(EventArg arg) {

        var item = arg.Item;
        items.Add(item);

        foreach (InventoryCell cell in inventoryCells) {

           if(item.ItemNameKey == cell.ItemNameKey) {
                
            }
           if(cell.IsEmpty) {
                cell.AddItemToCell(item);
                Debug.Log("AddItem: " + item.name);
                break;
            }       

        }
    }

    private void OnSetSelectedItemData(EventArg arg) {

        itemName.ChangeLocalization(arg.FirstStringArg);
        itemDescription.ChangeLocalization(arg.SecondStringArg);
        itemType.ChangeLocalization(arg.ThirdStringArg);
    }

    private void OnChangeItemTypeColor(EventArg arg) {

        itemType.gameObject.GetComponent<TextMeshProUGUI>().color = arg.Color;
    }
    #endregion
}