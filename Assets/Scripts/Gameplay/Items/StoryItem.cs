using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Story Item")]
public class StoryItem : Item
{
    [Header("Story:")]
     private StoryName story;

    protected override void OnEnable() {
        base.OnEnable();
        itemColor = new Color32(104, 106, 173, 255);
    }
}
