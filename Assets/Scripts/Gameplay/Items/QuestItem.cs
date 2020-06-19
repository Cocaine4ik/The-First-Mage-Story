using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Quest Item")]
public class QuestItem : Item
{
    protected override void OnEnable() {
        base.OnEnable();
        itemColor = new Color32(203, 190, 0, 255);
    }

}
