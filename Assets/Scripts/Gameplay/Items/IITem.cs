using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IITem {

    ItemName ItemName { get; }
    ItemType ItemType { get; }
    Sprite ItemIcon { get; }
    Color32 ItemColor { get; }


}