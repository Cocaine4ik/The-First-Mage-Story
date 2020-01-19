using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    #region Fields
    private int inventorySize;
    [SerializeField] private RelicItem test;
    [SerializeField] private Item testItem;
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

    private void Start() {

        items = new List<Item>();
        //items.Add(testItem);
        items.Add(test);
        if (items[0].GetType() == typeof(RelicItem)) {
            Debug.Log("it's ok");
        }
    }

    #endregion
}
