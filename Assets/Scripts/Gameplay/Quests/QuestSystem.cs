using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem Instance;

    private QuestJournal questJournal;
    private Dictionary<QuestName, Quest> quests = new Dictionary<QuestName, Quest>();
    private Dictionary<StoryName, Story> stories = new Dictionary<StoryName, Story>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {

            Destroy(gameObject);
        }
    }

    private void Start()
    {
        questJournal = GetComponent<QuestJournal>();
    }
    /// <summary>
    /// Add quest to quests, set quest status to Active
    /// Add quest to QuestJournal (UI presentation)
    /// </summary>
    /// <param name="name"></param>
    public void AddQuest(QuestName name)
    {
        var questName = name.ToString();
        var quest = Resources.Load<Quest>($"Quests/{questName}/{questName}");
        quest.Status = CompletnessStatus.Active;
        quests.Add(name, quest);

        AddTask(quest);
        questJournal.AddQuestToJournal(quest);
    }
    /// <summary>
    /// Set task status to Active
    /// Add Active task to current quest task
    /// </summary>
    /// <param name="quest"></param>
    public void AddTask(Quest quest)
    {
        foreach(QuestTask task in quest.QuestTasks)
        {
           if(task.Status == CompletnessStatus.NoActive)
            {
                task.Status = CompletnessStatus.Active;
                quest.CurrentTask = task;
                break;
            }
        }
    }
    public void CheckQuest(Quest quest)
    {

    }
    public void CheckTask(Task task)
    {

    }
    public void RefreshTask(Task task)
    {

    }
}
