using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    #region Fields

    private int inventorySize;

    [SerializeField] private List<Item> items;
    [SerializeField] private InventoryCell inventoryCellTemplate;
    [SerializeField] private Transform container;

    #endregion

    #region Methods

    private void OnEnable() {

        Render(items);
    }
    public void Render(List<Item> items) {

        items.ForEach(item => {

            var cell = Instantiate(inventoryCellTemplate, container);
            cell.Render(item);

        });
    }
    public void AddItem(Item item) {

        if(items.Count < inventorySize) {
            items.Add(item);
        }
        else {
            Debug.Log("Inventory is full");
        }
    }
    private void Start() {

    }

    #endregion
}
