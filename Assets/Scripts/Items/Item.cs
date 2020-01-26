using System;
using UnityEngine;

public class Item : ScriptableObject, IITem {

    #region Fields

    [Header("Item parameters")]
    [SerializeField] protected string itemName;
    [SerializeField] protected string itemType;
    [SerializeField] protected Sprite itemIcon;
    [SerializeField] protected string itemDescription;

    [Header("Localiztion keys")]
    [SerializeField] protected string itemNameKey;
    [SerializeField] protected string itemTypeKey;
    [SerializeField] protected string itemDescriptionKey;

    #endregion

    #region Properties

    public string ItemName => itemName;
    public string ItemType => itemType;
    public Sprite ItemIcon => itemIcon;
    public string ItemDescription => itemDescription;

    public string ItemNameKey => itemNameKey;
    public string ItemTypeKey => itemTypeKey;
    public string ItemDescriptionKey => itemDescriptionKey;

    #endregion
}
