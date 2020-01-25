using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour {

    #region Fields

    [SerializeField] Item itemData;

    private bool isPickup;

    #endregion

    #region Properties

    public Item ItemData => itemData;

    /// <summary>
    /// Get, set if the item is pickup
    /// </summary>
    public bool IsPickup {
        get { return isPickup; }
        set { isPickup = value; }
    }

    #endregion

    /// <summary>
    /// initialize isPickup field
    /// </summary>
    /// 
    #region Methods

    private void Start() {

        isPickup = false;
    }

    #endregion
}
