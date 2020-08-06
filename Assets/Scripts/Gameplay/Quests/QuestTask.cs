using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Quest Task")]
public class QuestTask : ScriptableObject
{
    [SerializeField] private TaskType taskType;
    [SerializeField] private int expReward;
    [SerializeField] private int goldReward;
    [SerializeField] private Item itemReward;

    [Header("Collect Task Options")]
    [SerializeField] private QuestItem itemToCollect;
    [SerializeField] private int collectItemNumber;
}
