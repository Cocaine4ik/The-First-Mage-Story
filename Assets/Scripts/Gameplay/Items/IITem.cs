using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IITem {

    ItemName ItemName { get; }
    ItemType ItemType { get; }
    Sprite ItemIcon { get; }
    Sprite ItemBorder { get; }
    Color32 ItemColor { get; }
    int ItemNumber { get; set; }
    bool IsSellable { get; }
    int ItemPrice { get; }

}