using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Quest Item")]
public class QuestItem : Item
{
    [Header("Quest Data")]
    [SerializeField] private Quest quest;
    protected override void OnEnable() {
        base.OnEnable();
        itemColor = new Color32(203, 190, 0, 255);
        isSellable = false;
        itemBorder = Resources.Load<Sprite>("Sprites/UI/Frames/frame-0-gold");
    }

}
