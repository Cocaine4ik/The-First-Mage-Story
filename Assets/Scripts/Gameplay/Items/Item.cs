﻿using System;
using UnityEngine;

public class Item : ScriptableObject, IITem {

    #region Fields

    [Header("Item parameters")]
    [SerializeField] protected Sprite itemIcon;
    [SerializeField] protected Color32 itemColor; 

    [Header("Localiztion keys")]
    [SerializeField] protected string itemNameKey = "Item.Name.";
    [SerializeField] protected string itemDescriptionKey = "Item.Description.";

    protected string itemTypeKey;
    protected string itemTypeKeyDefault = "Items.Type.";

    #endregion

    #region Properties

    public Sprite ItemIcon => itemIcon;
    public Color32 ItemColor => itemColor;

    public string ItemNameKey => itemNameKey;
    public string ItemDescriptionKey => itemDescriptionKey;
    public string ItemTypeKey => itemTypeKeyDefault + GetType().ToString();

    #endregion
}