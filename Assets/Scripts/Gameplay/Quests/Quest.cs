using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

    private string nameKey;
    private string descriptionKey;
    public QuestName Name;
    public QuestStatus Status = QuestStatus.Active;

    public string NameKey {
        get { return "Quests." + Name.ToString(); }
    }
    public string DescriptionKey {
        get { return "Quests.Description." + Name.ToString(); }
    }

    public Quest (QuestName name) {
        this.Name = name;
    }
}
