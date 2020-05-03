using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Story Item")]
public class StoryItem : Item
{
    [Header("Story:")]
    public StoryName story;

    private void OnEnable() {

        itemColor = new Color32(104, 106, 173, 255);

    }
}
