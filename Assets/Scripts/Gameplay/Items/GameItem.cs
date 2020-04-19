using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour {

    #region Fields

    [SerializeField] Item itemData;

    #endregion

    #region Properties

    public Item ItemData => itemData;

    #endregion

}
