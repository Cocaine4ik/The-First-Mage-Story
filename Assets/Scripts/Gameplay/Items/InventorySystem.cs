using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    private Inventory inventory;

    [SerializeField] private Dictionary<ItemName, QuestItem> questItems = new Dictionary<ItemName, QuestItem>();
    [SerializeField] private Dictionary<ItemName, SupplyItem> supplyItems = new Dictionary<ItemName, SupplyItem>();
    [SerializeField] private Dictionary<ItemName, RelicItem> relicItems = new Dictionary<ItemName, RelicItem>();
    [SerializeField] private Dictionary<ItemName, StoryItem> storyItems = new Dictionary<ItemName, StoryItem>();
    [SerializeField] private Dictionary<ItemName, TreasureItem> treasureItems = new Dictionary<ItemName, TreasureItem>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    public void AddItem(Item item)
    {
        switch(item.ItemType)
        {
            case ItemType.QuestItem: AddQuestItem(item.ItemName);  break;
            case ItemType.SupplyItem: AddSupplyItem(item.ItemName);  break;
            case ItemType.StoryItem: AddStoryItem(item.ItemName); break;
            case ItemType.RelicItem: AddRelicItem(item.ItemName); break;
            case ItemType.TreasureItem: AddTreasureItem(item.ItemName); break;
        }
    }

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
        if (!questItems.ContainsKey(name)) questItems.Add(name, questItem);
        else questItems[name].ItemNumber += 1;
        // check if quest is accepted
        var quest = QuestSystem.Instance.CheckQuest(questItem.QuestName);
        if (quest != null) 
        {   
            if (quest.CurrentTask.ItemToCollect == name) QuestSystem.Instance.UpdateTask(quest.CurrentTask);
        }

        // Add item to Inventory (UI presentataion)
        inventory.AddItemToInventory(questItems[name]);
    }

    private void AddSupplyItem(ItemName name)
    {
        var itemName = name.ToString();

        var supply = Instantiate(Resources.Load<SupplyItem>($"Data/Items/Supply/{itemName}"));
        if (!supplyItems.ContainsKey(name)) supplyItems.Add(name, supply);
        else supplyItems[name].ItemNumber += 1;

        // Add item to Inventory (UI presentataion)
        inventory.AddItemToInventory(supplyItems[name]);
    }

    private void AddStoryItem(ItemName name)
    {
        var itemName = name.ToString();

        var storyItem = Instantiate(Resources.Load<StoryItem>($"Data/Items/Story/{itemName}"));
        storyItems.Add(name, storyItem);
        QuestSystem.Instance.AddStory(storyItem.Story);

        // Add item to Inventory (UI presentataion)
        inventory.AddItemToInventory(storyItems[name]);
    }

    private void AddRelicItem(ItemName name)
    {
        var itemName = name.ToString();

        var relic = Instantiate(Resources.Load<RelicItem>($"Data/Items/Relic/{itemName}"));
        if (!relicItems.ContainsKey(name)) relicItems.Add(name, relic);
        else relicItems[name].ItemNumber += 1;

        // Add item to Inventory (UI presentataion)
        inventory.AddItemToInventory(relicItems[name]);
    }

    private void AddTreasureItem(ItemName name)
    {
        var itemName = name.ToString();

        var treasure = Instantiate(Resources.Load<TreasureItem>($"Data/Items/Treasure/{itemName}"));
        if (!treasureItems.ContainsKey(name)) treasureItems.Add(name, treasure);
        else treasureItems[name].ItemNumber += 1;

        // Add item to Inventory (UI presentataion)
        inventory.AddItemToInventory(treasureItems[name]);
    }
}
