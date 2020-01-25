using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    #region Fields
    [SerializeField] private int inventorySize;

    [SerializeField] private List<Item> items;
    [SerializeField] private List<InventoryCell> inventoryCells;
    [SerializeField] private InventoryCell inventoryCellTemplate;
    [SerializeField] private Transform storage;

    #endregion

    #region Methods

    private void OnEnable() {

        AddInventoryCells();

        EventManager.StartListening(EventName.PickupItem, AddItem);

    }

    private void OnDisable() {

    }
    private void Start() {
        EventManager.StartListening(EventName.PickupItem, AddItem);
    }

    private void AddInventoryCells() {

        for (int i = 0; i < inventorySize; i++) {

            var cell = Instantiate(inventoryCellTemplate, storage);
            cell.SetId(i);
            inventoryCells.Add(cell);

        }
    }


    public void AddItem(EventArg arg) {
       
        foreach (InventoryCell cell in inventoryCells) {

           if(cell.IsEmpty) {
                cell.Render(arg.Item);
                break;
            }
        }

        /*
        if(items.Count < inventorySize) {
            items.Add(item);
        }
        else {
            Debug.Log("Inventory is full");
        }*/
    }


    #endregion
}
