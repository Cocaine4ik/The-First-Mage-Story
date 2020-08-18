using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Quest Task")]
public class QuestTask : ScriptableObject, IJournalItem
{
    #region Fields

    [SerializeField] private QuestName questName;
    [SerializeField] private int id;
    [SerializeField] private TaskType taskType;
    [SerializeField] private CompletnessStatus status = CompletnessStatus.NoActive;
    [SerializeField] private int expReward = 0;
    [SerializeField] private int goldReward = 0;
    [SerializeField] private Item itemReward;

    [Header("Collect Task Options")]
    [SerializeField] private ItemName itemToCollect;
    [SerializeField] private int collectItemNumber;

    private int collectedItemNumber = 0;

    #endregion

    #region Properties

    public QuestName QuestName => questName;
    public CompletnessStatus Status { get => status; set => status = value; }
    public TaskType TaskType => taskType;
    public int Id => id;
    public string NameKey => "Quests.Tasks." + questName.ToString() + "-" + id;
    public string DescriptionKey => "Quests.Description." + questName.ToString() + "-" + id;
    public ItemName ItemToCollect => itemToCollect;
    public int CollectItemNumber => collectItemNumber;
    public int CollectedItemNumber { get => collectedItemNumber; set => collectedItemNumber = value; }
    public int ExpReward => expReward;
    public int GoldReward => goldReward;
    public Item ItemReward => itemReward;

    #endregion
}
