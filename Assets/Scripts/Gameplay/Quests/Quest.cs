
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Quest")]
public class Quest : ScriptableObject, IJournalItem {

    [SerializeField] private QuestName questName;
    [SerializeField] private CompletnessStatus status = CompletnessStatus.NoActive;
    [SerializeField] private List<QuestTask> questTasks;
    private QuestTask currentTask;


    public List<QuestTask> QuestTasks => questTasks;
    public QuestTask CurrentTask { get => currentTask; set => currentTask = value; }
    public string NameKey => "Quests." + questName.ToString();
    public string DescriptionKey => "Quests.Description." + questName.ToString() + "-" + currentTask.Id;
    public CompletnessStatus Status { get => status; set => status = value; }
}
