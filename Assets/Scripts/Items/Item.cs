using System;
using UnityEngine;

public class Item : ScriptableObject, IITem {

    #region Fields

    [Header("Item parameters")]
    [SerializeField] protected Sprite itemIcon;

    [Header("Localiztion keys")]
    [SerializeField] protected string itemNameKey;
    [SerializeField] protected string itemDescriptionKey;

    protected string itemTypeKey;
    protected string itemTypeKeyDefault = "Items.Type.";

    #endregion

    #region Properties

    public Sprite ItemIcon => itemIcon;

    public string ItemNameKey => itemNameKey;
    public string ItemDescriptionKey => itemDescriptionKey;
    public string ItemTypeKey => itemTypeKeyDefault + GetType().ToString();

    #endregion
}
