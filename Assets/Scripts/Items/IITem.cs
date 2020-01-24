using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IITem {

    string ItemName { get; }
    string ItemType { get; }
    Sprite ItemIcon { get; }
    string ItemDescription { get;}

    /// <summary>
    /// keys for localiztion
    /// </summary>
    string ItemNameKey { get;  }
    string ItemTypeKey { get; }
    string ItemDescriptionKey { get; }


}