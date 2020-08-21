using System;
using UnityEngine;

public class Item : ScriptableObject, IITem {

    #region Fields

    [Header("Item Data")]
    [SerializeField] protected ItemName itemName;
    [SerializeField] protected ItemType itemType;
    [SerializeField] protected Sprite itemIcon;
    [SerializeField] protected Sprite itemBorder;
    [SerializeField] protected Color32 itemColor;
    [SerializeField] protected int itemNumber = 1;

    [Header("Buy/Sell Data")]
    [SerializeField] protected bool isSellable;
    [SerializeField] protected int itemPrice;
    
    #endregion

    #region Properties

    public ItemName ItemName => itemName;
    public ItemType ItemType => itemType;
    public Sprite ItemIcon => itemIcon;
    public Sprite ItemBorder => itemBorder;
    public Color32 ItemColor => itemColor;
    public bool IsSellable => isSellable;
    public int ItemPrice => itemPrice;

    public int ItemNumber {
        get => itemNumber;
        set
        {
            itemNumber = value;
            EventManager.TriggerEvent(EventName.ChangeItemNumber, new EventArg(itemName, itemNumber));
        }
    }
    #endregion

    protected virtual void OnEnable() {
        switch(GetType().ToString())
        {
            case "QuestItem": itemType = ItemType.Quest; break;
            case "SupplyItem": itemType = ItemType.Supply; break;
            case "RelicItem": itemType = ItemType.Relic; break;
            case "StoryItem": itemType = ItemType.Story; break;
            case "TreasureItem": itemType = ItemType.Treasure; break;
            default: itemType = ItemType.Undefined; break;
        }
        itemBorder = Resources.Load<Sprite>("Sprites/UI/Frames/frame-0-grey");
    }
}
