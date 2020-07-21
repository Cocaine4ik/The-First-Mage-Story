using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureItem : Item
{

    protected override void OnEnable()
    {
        base.OnEnable();
        itemColor = new Color32(0, 0, 0, 255);
        isSellable = true;
    }
}
