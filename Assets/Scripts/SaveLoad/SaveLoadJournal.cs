using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadJournal : SaveLoadData
{
    private QuestJournal questJournal;

    private void Awake()
    {
        questJournal = GetComponent<QuestJournal>();
    }

    protected override void OnLoadData(EventArg arg)
    {
        foreach (QuestName name in Enum.GetValues(typeof(QuestName)))
        {
            if (PlayerPrefs.HasKey("QuestData." + name.ToString()))
            {
                var questData = PlayerPrefs.GetString("QuestData." + name.ToString());
                var splitQuestData = questData.Split('.');
                var questName = (QuestName)Enum.Parse(typeof(QuestName), splitQuestData[0]);
                var questStatus = (CompletnessStatus)Enum.Parse(typeof(CompletnessStatus), splitQuestData[1]);
                var currentTaskId = Int16.Parse(splitQuestData[2]);

                QuestSystem.Instance.AddQuest(questName);
                var quest = QuestSystem.Instance.Quests[questName];
                foreach (QuestTask task in QuestSystem.Instance.Quests[questName].QuestTasks)
                {
                    if (task.Id != currentTaskId)
                    {
                        task.Status = CompletnessStatus.Done;
                        questJournal.CloseTask(task);
                        QuestSystem.Instance.AddTask(quest);
                        questJournal.AddTaskToJournal(quest);
                    }
                }
                if (questStatus == CompletnessStatus.Done || questStatus == CompletnessStatus.Failed)
                {
                    questJournal.CloseTask(quest.CurrentTask);
                    quest.Status = questStatus;
                }
            }
        }
    }

    protected override void OnSaveData(EventArg arg)
    {
        foreach(var quest in QuestSystem.Instance.Quests)
        {
            PlayerPrefs.SetString("QuestData." + quest.Key.ToString(), quest.Key.ToString() +
                "." + quest.Value.Status.ToString() + "." + quest.Value.CurrentTask.Id.ToString());
        }
    }
}
