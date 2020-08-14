using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Story Item")]
public class StoryItem : Item
{
    [Header("Story Data")]
    [SerializeField] private StoryName story;

    public StoryName Story => story;

    protected override void OnEnable() {
        base.OnEnable();
        itemColor = new Color32(0, 0, 0, 255);
        isSellable = true;
    }
}
