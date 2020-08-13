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
        var quest = Instantiate(Resources.Load<Quest>($"Quests/{questName}/{questName}"));
        quests.Add(name, quest);
        quests[name].Status = CompletnessStatus.Active;

        Debug.Log("Quest:" + quest.name + " added.");
        AddTask(quests[name]);

        questJournal.AddQuestToJournal(quests[name]);
    }
    /// <summary>
    /// Set task status to Active
    /// Add Active task to current quest task
    /// </summary>
    /// <param name="quest"></param>
    public void AddTask(Quest quest)
    {
        // clear links to SO
        for (int i = 0; i < quest.QuestTasks.Count-1; i++)
        {
            quest.QuestTasks[i] = Instantiate(quest.QuestTasks[i]);
        }
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
    public Quest CheckQuest(QuestName name)
    {
        if (quests.ContainsKey(name)) return quests[name];
        return null;
    }
    public QuestTask CheckTask(Quest quest, TaskType type)
    {
        if (quest.CurrentTask.TaskType == type) return quest.CurrentTask;
        return null;
    }
    public void RefreshTask(QuestTask task)
    {
        switch(task.TaskType)
        {
            case TaskType.Collect: break;
            case TaskType.Decide: break;
            case TaskType.Deliver: break;
            case TaskType.Reach: break;
            case TaskType.Slay: break;
            case TaskType.Talk: 
                task.Status = CompletnessStatus.Done;
                questJournal.CloseTask(task);
                break;
        }
    }
}
