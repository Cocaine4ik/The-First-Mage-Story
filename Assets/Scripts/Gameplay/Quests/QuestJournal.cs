using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

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
    [SerializeField] private TextMeshProUGUI questDescription;

    [Header("For stories: ")]
    [SerializeField] private Transform storyNamesContainer;
    [SerializeField] private TextMeshProUGUI storyDescription;

    [Header("For quest and story: ")]
    [SerializeField] private GameObject questNameButtonPrefab;

    // quest names and descriptions
    private Dictionary<QuestName, Quest> quests = new Dictionary<QuestName, Quest>();
    private Dictionary<StoryName, Story> stories = new Dictionary<StoryName, Story>();
    

    private List<GameObject> mainPageChilds = new List<GameObject>();
    private List<GameObject> questPageChilds = new List<GameObject>();
    private List<GameObject> storyPageChilds = new List<GameObject>();

    private RectTransform mainPageRect;
    private RectTransform questPageRect;
    private RectTransform storyPageRect;
    private RectTransform backButtonRect;
    private RectTransform closeButtonRect;

    private void OnEnable() {

    }
    private void OnDisable() {
        EventManager.StopListening(EventName.AddQuest, OnAddJorunalItem);
    }
    protected override void Start() {

        base.Start();

        mainPageChilds = UnityExtensions.CreateChildsList(mainPage);
        questPageChilds = UnityExtensions.CreateChildsList(questPage);
        storyPageChilds = UnityExtensions.CreateChildsList(storyPage);

        EventManager.StartListening(EventName.AddQuest, OnAddJorunalItem);
        EventManager.TriggerEvent(EventName.AddQuest, new EventArg(new Quest(QuestName.FirstTrial)));

        mainPageRect = mainPage.GetComponent<RectTransform>();
        questPageRect = questPage.GetComponent<RectTransform>();
        storyPageRect = storyPage.GetComponent<RectTransform>();
        closeButtonRect = closeButton.GetComponent<RectTransform>();
        backButtonRect = backButton.GetComponent<RectTransform>();

        backButton.SetActive(!gameObject.activeSelf);
}

    private void OnAddJorunalItem(EventArg arg) {

        
        if(arg.Quest != null) {
            var quest = arg.Quest;
            quests.Add(quest.Name, quest);
            AddJorunalItem(questNamesContainer, quest.NameKey, quest);
        }
        else if(arg.Story != null) {
            var story = arg.Story;
            stories.Add(story.Name, story);
            AddJorunalItem(storyNamesContainer, story.NameKey, story);
        }

    }

    private void AddJorunalItem(Transform container, string nameKey, IJournalItem journalItem) {

        var button = Instantiate(questNameButtonPrefab, container);
        button.GetComponentInChildren<LocalizedTMPro>().ChangeLocalization(nameKey);
        button.GetComponent<Button>().onClick.AddListener(() => OnShowJournalItemDesciption(journalItem));
    }

    public void OnShowJournalItemDesciption(IJournalItem journalItem) {

        var journalItemNameText = GetComponentInChildren<LocalizedTMPro>().LocalizationKey;

        // remove localization prefix
        journalItemNameText = journalItemNameText.Remove(0, 7);

        if (journalItem.GetType().ToString() == "Quest") {
            QuestName questName = (QuestName)Enum.Parse(typeof(QuestName), journalItemNameText);
            questDescription.text = quests[questName].DescriptionKey;
        }
        else if (journalItem.GetType().ToString() == "Story") {
            StoryName storyName = (StoryName)Enum.Parse(typeof(StoryName), journalItemNameText);
            questDescription.text = stories[storyName].DescriptionKey;
        }
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
