using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UnityEngine;

public class InventorySystem : Singleton<InventorySystem>
{
    private Inventory inventory;

    public Dictionary<ItemName, QuestItem> QuestItems = new Dictionary<ItemName, QuestItem>();
    public Dictionary<ItemName, SupplyItem> SupplyItems = new Dictionary<ItemName, SupplyItem>();
    public Dictionary<ItemName, RelicItem> RelicItems = new Dictionary<ItemName, RelicItem>();
    public Dictionary<ItemName, StoryItem> StoryItems = new Dictionary<ItemName, StoryItem>();
    public Dictionary<ItemName, TreasureItem> TreasureItems = new Dictionary<ItemName, TreasureItem>();

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    public void AddItem(Item item)
    {
        switch(item.ItemType)
        {
            case ItemType.Quest: AddQuestItem(item.ItemName);  break;
            case ItemType.Supply: AddSupplyItem(item.ItemName);  break;
            case ItemType.Story: AddStoryItem(item.ItemName); break;
            case ItemType.Relic: AddRelicItem(item.ItemName); break;
            case ItemType.Treasure: AddTreasureItem(item.ItemName); break;
        }
    }

    public void RemoveItem(ItemName name)
    {
        RemoveItem(SupplyItems, name);
        RemoveItem(QuestItems, name);
        RemoveItem(RelicItems, name);
        RemoveItem(TreasureItems, name);
        RemoveItem(StoryItems, name);       
    }

    #region RemoveItem() overloads

    private void RemoveItem(Dictionary<ItemName, QuestItem> items, ItemName name)
    {
        if (items.ContainsKey(name))
        {
            if (items[name].ItemNumber > 1) items[name].ItemNumber -= 1;
            else
            {
                QuestItems.Remove(name);
                inventory.RemoveItemFromInventory(name);
            }
        }
    }
    private void RemoveItem(Dictionary<ItemName, SupplyItem> items, ItemName name)
    {
        if (items.ContainsKey(name))
        {
            if (items[name].ItemNumber > 1) items[name].ItemNumber -= 1;
            else
            {
                QuestItems.Remove(name);
                inventory.RemoveItemFromInventory(name);
            }
        }
    }
    private void RemoveItem(Dictionary<ItemName, RelicItem> items, ItemName name)
    {
        if (items.ContainsKey(name))
        {
            if (items[name].ItemNumber > 1) items[name].ItemNumber -= 1;
            else
            {
                QuestItems.Remove(name);
                inventory.RemoveItemFromInventory(name);
            }
        }
    }
    private void RemoveItem(Dictionary<ItemName, TreasureItem> items, ItemName name)
    {
        if (items.ContainsKey(name))
        {
            if (items[name].ItemNumber > 1) items[name].ItemNumber -= 1;
            else
            {
                QuestItems.Remove(name);
                inventory.RemoveItemFromInventory(name);
            }
        }
    }
    private void RemoveItem(Dictionary<ItemName, StoryItem> items, ItemName name)
    {
        if (items.ContainsKey(name))
        {
                QuestItems.Remove(name);
                inventory.RemoveItemFromInventory(name);
        }
    }

    #endregion

    /// <summary>
    /// Add Quest Item
    /// </summary>
    /// <param name="name"></param>
    private void AddQuestItem(ItemName name)
    {
        var itemName = name.ToString();
        Debug.Log(itemName);
        // load clone form resources
        var questItem = Instantiate(Resources.Load<QuestItem>($"Data/Items/Quest/{itemName}"));
        if (!QuestItems.ContainsKey(name))
        {
            QuestItems.Add(name, questItem);
            // Add item to Inventory (UI presentataion)
            inventory.AddItemToInventory(QuestItems[name]);
        }
        else { QuestItems[name].ItemNumber += 1; }
        // check if quest is accepted
        var quest = QuestSystem.Instance.CheckQuest(questItem.QuestName);
        if (quest != null) 
        {   
            if (quest.CurrentTask.ItemToCollect == name) QuestSystem.Instance.UpdateTask(quest.CurrentTask);
        }
    }

    private void AddSupplyItem(ItemName name)
    {
        var itemName = name.ToString();

        var supply = Instantiate(Resources.Load<SupplyItem>($"Data/Items/Supply/{itemName}"));
        if (!SupplyItems.ContainsKey(name))
        {
            SupplyItems.Add(name, supply);
            // Add item to Inventory (UI presentataion)
            inventory.AddItemToInventory(SupplyItems[name]);
        }
        else SupplyItems[name].ItemNumber += 1;
    }

    private void AddStoryItem(ItemName name)
    {
        var itemName = name.ToString();

        var storyItem = Instantiate(Resources.Load<StoryItem>($"Data/Items/Story/{itemName}"));
        StoryItems.Add(name, storyItem);
        QuestSystem.Instance.AddStory(storyItem.Story);

        // Add item to Inventory (UI presentataion)
        inventory.AddItemToInventory(StoryItems[name]);
    }

    private void AddRelicItem(ItemName name)
    {
        var itemName = name.ToString();

        var relic = Instantiate(Resources.Load<RelicItem>($"Data/Items/Relic/{itemName}"));
        if (!RelicItems.ContainsKey(name))
        {
            RelicItems.Add(name, relic);
            // Add item to Inventory (UI presentataion)
            inventory.AddItemToInventory(RelicItems[name]);
        }
        else RelicItems[name].ItemNumber += 1;
    }

    private void AddTreasureItem(ItemName name)
    {
        var itemName = name.ToString();

        var treasure = Instantiate(Resources.Load<TreasureItem>($"Data/Items/Treasure/{itemName}"));
        if (!TreasureItems.ContainsKey(name))
        {
            TreasureItems.Add(name, treasure);
            // Add item to Inventory (UI presentataion)
            inventory.AddItemToInventory(TreasureItems[name]);
        }
        else TreasureItems[name].ItemNumber += 1;

    }
}
