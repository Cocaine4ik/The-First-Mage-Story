using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    #region Fields
    private int inventorySize;
    /// <summary>
    /// 
    /// </summary>
    private List<Item> items;
    /// <summary>
    /// 
    /// </summary>
    private List<Item> relics;
    #endregion

    #region Methods

    public void AddItem(Item item) {

        if(items.Count < inventorySize) {
            items.Add(item);
        }
        else {
            Debug.Log("Inventory is full");
        }
    }

    #endregion
}
