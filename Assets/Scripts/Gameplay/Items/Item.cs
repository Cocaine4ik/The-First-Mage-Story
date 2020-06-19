using System;
using UnityEngine;

public class Item : ScriptableObject, IITem {

    #region Fields

    [Header("Item parameters")]
    [SerializeField] protected ItemName itemName;
    [SerializeField] protected ItemType itemType;
    [SerializeField] protected Sprite itemIcon;
    [SerializeField] protected Color32 itemColor;

    #endregion

    #region Properties

    public ItemName ItemName => itemName;
    public ItemType ItemType => itemType;
    public Sprite ItemIcon => itemIcon;
    public Color32 ItemColor => itemColor;

    #endregion

    protected virtual void OnEnable() {

        itemType = (ItemType)Enum.Parse(typeof(ItemType), GetType().ToString());
    }
}
