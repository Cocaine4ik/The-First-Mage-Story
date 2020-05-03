using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Quest Item")]
public class QuestItem : Item
{
    private void OnEnable() {
        itemColor = new Color32(203, 190, 0, 255);
    }

}
