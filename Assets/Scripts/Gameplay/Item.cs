using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    #region Fields

    [SerializeField] Sprite itemIcon;
    [SerializeField] private string itemName;
    [SerializeField] private bool isRelic;
    [SerializeField] private bool isQuestItem;
    [SerializeField] private bool isLoreItem;
    [SerializeField] private int itemPrice;
    [SerializeField] private string itemDescription;

    private bool isPickup;

    #endregion

    #region Properties

    /// <summary>
    /// Get item icon
    /// </summary>
    public Sprite ItemIcon {
        get { return itemIcon; }
    }

    /// <summary>
    /// Get item name
    /// </summary>
    public string ItemName {
        get { return itemName; }
    }

    /// <summary>
    /// Get true if item is relic
    /// </summary>
    public bool IsRelic {
        get { return isRelic; }
    }

    /// <summary>
    /// Get true if item is quest item
    /// </summary>
    public bool IsQuestItem {
        get { return isQuestItem; }
    }

    /// <summary>
    /// Get true if item is lore item
    /// </summary>
    public bool IsLoreItem {
        get { return isLoreItem; }
    }

    /// <summary>
    /// Get value of the item price
    /// </summary>
    public int ItemPrice {
        get { return itemPrice; }
    }

    /// <summary>
    /// Get the item description
    /// </summary>
    public string ItemDescription {
        get { return itemDescription; }
    }
    #endregion

    /// <summary>
    /// Get, set if the item is pickup
    /// </summary>
    public bool IsPickup {
        get { return isPickup; }
        set { isPickup = value; }
    }

    /// <summary>
    /// initialize isPickup field
    /// </summary>
    #region Methods

    private void Start() {

        isPickup = false;
    }

    #endregion
}
