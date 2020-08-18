using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

/// <summary>
/// Quest Journal (UI presentation)
/// </summary>
public class QuestJournal : UIElementBase
{
    [Header("Journal pages:")]
    [SerializeField] private Transform questPage;
    [SerializeField] private Transform storyPage;

    [Header("For quests: ")]
    [SerializeField] private Transform questNamesContainer;
    [SerializeField] private Transform questTasksContainer;
    [SerializeField] private LocalizedTMPro questDescription;

    [Header("For stories: ")]
    [SerializeField] private Transform storyNamesContainer;
    [SerializeField] private LocalizedTMPro storyDescription;

    [Header("For quest and story: ")]
    [SerializeField] private GameObject journalItemNameButtonPrefab;
    
    private List<GameObject> questPageChilds = new List<GameObject>();
    private List<GameObject> storyPageChilds = new List<GameObject>();

    private RectTransform questPageRect;
    private RectTransform storyPageRect;

    public bool IsQuestPage { get; set; }
    public bool IsStoriesPage { get; set; }

    protected override void Start() {

        base.Start();

        questPageChilds = UnityExtensions.CreateChildsList(questPage);
        storyPageChilds = UnityExtensions.CreateChildsList(storyPage);

        QuestSystem.Instance.AddQuest(QuestName.FirstTrial);

        questPageRect = questPage.GetComponent<RectTransform>();
        storyPageRect = storyPage.GetComponent<RectTransform>();

    }
    /// <summary>
    /// Add quest to Journal
    /// Instantiate button in quest names container
    /// Change button text localization to quest name
    /// Add onClick event to button which invoke ShowQuestInfo method
    /// Add first task
    /// </summary>
    /// <param name="quest"></param>
    public void AddQuestToJournal(Quest quest)
    {
        var button = Instantiate(journalItemNameButtonPrefab, questNamesContainer);
        button.GetComponentInChildren<LocalizedTMPro>().ChangeLocalization(quest.NameKey);
        button.GetComponent<Button>().onClick.AddListener(() => ShowTaskDescription(quest.CurrentTask));
        AddTaskToJournal(quest);
    }

    /// <summary>
    /// Add story to Journal
    /// Intantiate button in story names container
    /// Change button text localization to story name
    /// Add onClick event to button which invoke ShowStoryDescription method
    /// </summary>
    /// <param name="story"></param>
    public void AddStoryToJournal(Story story)
    {
        var button = Instantiate(journalItemNameButtonPrefab, storyNamesContainer);
        button.GetComponentInChildren<LocalizedTMPro>().ChangeLocalization(story.NameKey);
        button.GetComponent<Button>().onClick.AddListener(() => ShowStoryDescription(story));
    }

    /// <summary>
    /// Add task to Journal
    /// Intantiate button in tasks name container
    /// Change task text localization to task name
    /// Add onClick event to button which invoke ShowTaskDescription method
    /// </summary>
    /// <param name="quest"></param>
    public void AddTaskToJournal(Quest quest)
    {

        var button = Instantiate(journalItemNameButtonPrefab, questTasksContainer);
        button.name = quest.CurrentTask.NameKey;
        button.GetComponentInChildren<LocalizedTMPro>().ChangeLocalization(quest.CurrentTask.NameKey);
        var task = quest.CurrentTask;
        button.GetComponent<Button>().onClick.AddListener(() => ShowTaskDescription(task));

    }

    public void CloseTask(QuestTask task)
    {
        Debug.Log("CloseTask");
        var taskButton = questTasksContainer.Find(task.NameKey);
        var taskButtonText = taskButton.GetComponentInChildren<TextMeshProUGUI>();
        
        taskButtonText.fontStyle = FontStyles.Strikethrough;
    }
    public void ShowTaskDescription(QuestTask task)
    {
        questDescription.ChangeLocalization(task.DescriptionKey);
    }
    public void ShowStoryDescription(Story story)
    {
        storyDescription.ChangeLocalization(story.DescriptionKey);
    }

    /// <summary>
    /// Invoke closing QuestJournal event
    /// </summary>
    public void CloseQuestJournalButton() {
        EventManager.TriggerEvent(EventName.CloseQuestJournal);
    }

    /// <summary>
    /// Show on quest page and back button show off main page
    /// </summary>
    public void OpenQuestsPage() {

        OpenCloseUIEelement(storyPageRect, storyPageChilds);
        OpenCloseUIEelement(questPageRect, questPageChilds);
    }
    public void OpenStoriesPage()
    {
        OpenCloseUIEelement(questPageRect, questPageChilds);
        OpenCloseUIEelement(storyPageRect, storyPageChilds);
    }

    private void OpenCloseUIEelement(RectTransform elementRect, List<GameObject> uiElementChilds) {

        UnityExtensions.SetActiveGameObjectChilds(uiElementChilds);

        elementRect.SetAsLastSibling();

    }

}
