using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Story Item")]
public class StoryItem : Item
{
    [Header("Story:")]
    public StoryName story;
}
