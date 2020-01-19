using System;
using UnityEngine;

public class ItemBase : ScriptableObject, IITem {

    #region Fields

    [Header("Item parameters")]
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite itemIcon;
    [SerializeField] protected string itemDescription;

    [Header("Localiztion keys")]
    [SerializeField] protected string itemNameKey;
    [SerializeField] protected string itemDescriptionKey;

    #endregion

    #region Properties

    public string ItemName => throw new NotImplementedException();
    public Sprite ItemIcon => throw new NotImplementedException();
    public string ItemDescription => throw new NotImplementedException();

    public string ItemNameKey => throw new NotImplementedException();
    public string ItemDescriptionKey => throw new NotImplementedException();

    #endregion
}
