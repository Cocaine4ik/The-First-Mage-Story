using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadInventory : SaveLoadData
{
    protected override void OnLoadData(EventArg arg)
    {
        // fore each item name in ItemName enum
        foreach (ItemName name in Enum.GetValues(typeof(ItemName)))
        {
            // if PlayerPrefs has this key
            if(PlayerPrefs.HasKey("ItemData." + name.ToString()))
            {
                var itemData = PlayerPrefs.GetString("ItemData." + name.ToString());
                Debug.Log(itemData);
                var splitItemData = itemData.Split('.');
                var itemName = splitItemData[0];
                var itemType = splitItemData[1];
                var itemNumber = Int16.Parse(splitItemData[2]);
                var item = Resources.Load<Item>($"Data/Items/{itemType}/{itemName}");
                Debug.Log("path: " + $"Items/{itemType}/{itemName}");

                // add item (item number times)
                for (int i = 0; i < itemNumber; i++)
                {
                    InventorySystem.Instance.AddItem(item);
                }
            }
        }
    }

    protected override void OnSaveData(EventArg arg)
    {
        // delete all ItemData keys saved before
        foreach (ItemName name in Enum.GetValues(typeof(ItemName)))
        {
            if(PlayerPrefs.HasKey("ItemData." + name.ToString()))
            {
                PlayerPrefs.DeleteKey("ItemData." + name.ToString());
            }
        }
        // check each Dictionary with items and save item - item name + item type  + item number
        foreach (var item in InventorySystem.Instance.QuestItems)
        {
            PlayerPrefs.SetString("ItemData." + item.Key.ToString(), item.Key.ToString() +
                "." + item.Value.ItemType.ToString() + "." + item.Value.ItemNumber);
        }
        foreach (var item in InventorySystem.Instance.SupplyItems)
        {
            PlayerPrefs.SetString("ItemData." + item.Key.ToString(), item.Key.ToString() +
                "." + item.Value.ItemType.ToString() + "." + item.Value.ItemNumber);
        }
        foreach (var item in InventorySystem.Instance.StoryItems)
        {
            PlayerPrefs.SetString("ItemData." + item.Key.ToString(), item.Key.ToString() +
                "." + item.Value.ItemType.ToString() + "." + item.Value.ItemNumber);
        }
        foreach (var item in InventorySystem.Instance.RelicItems)
        {
            PlayerPrefs.SetString("ItemData." + item.Key.ToString(), item.Key.ToString() +
                "." + item.Value.ItemType.ToString() + "." + item.Value.ItemNumber);
        }
        foreach (var item in InventorySystem.Instance.TreasureItems)
        {
            PlayerPrefs.SetString("ItemData." + item.Key.ToString(), item.Key.ToString() +
                "." + item.Value.ItemType.ToString() + "." + item.Value.ItemNumber);
        }
    }
}
