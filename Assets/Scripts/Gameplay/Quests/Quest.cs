
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Quest")]
public class Quest : ScriptableObject, IJournalItem {

    [SerializeField] private QuestName questName;
    [SerializeField] private QuestStatus questStatus = QuestStatus.Active;

    [SerializeField] private List<QuestTask> questTasks;
    public string NameKey => "Quests." + questName.ToString();
    public string DescriptionKey => "Quests.Description." + questName.ToString();


}
