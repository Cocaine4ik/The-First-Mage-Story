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
    [SerializeField] private Transform mainPage;
    [SerializeField] private Transform questPage;
    [SerializeField] private Transform storyPage;

    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject closeButton;

    [Header("For quests: ")]
    [SerializeField] private Transform questNamesContainer;
    [SerializeField] private Transform questTasksConainer;
    [SerializeField] private LocalizedTMPro questDescription;

    [Header("For stories: ")]
    [SerializeField] private Transform storyNamesContainer;
    [SerializeField] private LocalizedTMPro storyDescription;

    [Header("For quest and story: ")]
    [SerializeField] private GameObject journalItemNameButtonPrefab;
    
    private List<GameObject> mainPageChilds = new List<GameObject>();
    private List<GameObject> questPageChilds = new List<GameObject>();
    private List<GameObject> storyPageChilds = new List<GameObject>();

    private RectTransform mainPageRect;
    private RectTransform questPageRect;
    private RectTransform storyPageRect;
    private RectTransform backButtonRect;
    private RectTransform closeButtonRect;

    protected override void Start() {

        base.Start();

        mainPageChilds = UnityExtensions.CreateChildsList(mainPage);
        questPageChilds = UnityExtensions.CreateChildsList(questPage);
        storyPageChilds = UnityExtensions.CreateChildsList(storyPage);

        QuestSystem.Instance.AddQuest(QuestName.FirstTrial);

        mainPageRect = mainPage.GetComponent<RectTransform>();
        questPageRect = questPage.GetComponent<RectTransform>();
        storyPageRect = storyPage.GetComponent<RectTransform>();
        closeButtonRect = closeButton.GetComponent<RectTransform>();
        backButtonRect = backButton.GetComponent<RectTransform>();

        backButton.SetActive(!gameObject.activeSelf);
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
        var button = Instantiate(journalItemNameButtonPrefab, questTasksConainer);
        Debug.Log(quest.CurrentTask.name);
        button.GetComponentInChildren<LocalizedTMPro>().ChangeLocalization(quest.CurrentTask.NameKey);
        button.GetComponent<Button>().onClick.AddListener(() => ShowTaskDescription(quest.CurrentTask));
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
    public void OpenQuestsPageButton() {

        OpenCloseUIEelement(questPageRect, questPageChilds);
    }

    public void OpenStoryPageButton() {

        OpenCloseUIEelement(storyPageRect, storyPageChilds);
    }

    private void OpenCloseUIEelement(RectTransform elementRect, List<GameObject> uiElementChilds) {

        UnityExtensions.SetActiveGameObjectChilds(mainPageChilds);
        UnityExtensions.SetActiveGameObjectChilds(uiElementChilds);

        mainPage.gameObject.SetActive(!gameObject.activeSelf);
        backButton.SetActive(gameObject.activeSelf);

        elementRect.SetAsLastSibling();

        backButtonRect.SetAsLastSibling();
        closeButtonRect.SetAsLastSibling();
    }

    public void BackButton() {

        if(UnityExtensions.IsActiveChilds(questPageChilds)) {
            UnityExtensions.SetActiveGameObjectChilds(questPageChilds);
            questPageRect.SetAsFirstSibling();
        }
        else if (UnityExtensions.IsActiveChilds(storyPageChilds)) {
            UnityExtensions.SetActiveGameObjectChilds(storyPageChilds);
            storyPageRect.SetAsFirstSibling();
        }
        UnityExtensions.SetActiveGameObjectChilds(mainPageChilds);

        mainPage.gameObject.SetActive(gameObject.activeSelf);
        mainPageRect.SetAsLastSibling();
        closeButtonRect.SetAsLastSibling();
        backButton.SetActive(!gameObject.activeSelf);
    }

}
