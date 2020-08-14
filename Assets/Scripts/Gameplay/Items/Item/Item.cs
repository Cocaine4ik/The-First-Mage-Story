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

    public int ItemNumber { get => itemNumber; set => itemNumber = value; }
    #endregion

    protected virtual void OnEnable() {

        itemType = (ItemType)Enum.Parse(typeof(ItemType), GetType().ToString());
        itemBorder = Resources.Load<Sprite>("Sprites/UI/Frames/frame-0-grey");
    }
}
