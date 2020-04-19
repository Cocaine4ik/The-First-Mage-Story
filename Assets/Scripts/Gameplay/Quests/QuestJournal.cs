using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class QuestJournal : MonoBehaviour
{
    [SerializeField] private Transform mainPage;
    [SerializeField] private Transform questPage;
    [SerializeField] private GameObject backButton;

    [SerializeField] private Transform questNamesContainer;
    [SerializeField] private TextMeshProUGUI questDescription;
    [SerializeField] private GameObject questNameButtonPrefab;

    // quest names and descriptions
    private Dictionary<QuestName, Quest> quests = new Dictionary<QuestName, Quest>();

    private List<GameObject> mainPageChilds = new List<GameObject>();
    private List<GameObject> questPageChilds = new List<GameObject>();

    private void OnEnable() {

    }
    private void OnDisable() {
        EventManager.StopListening(EventName.AddQuest, AddQuestEvent);
    }
    private void Start() {

        mainPageChilds = UnityExtensions.CreateChildsList(mainPage);
        questPageChilds = UnityExtensions.CreateChildsList(questPage);

        EventManager.StartListening(EventName.AddQuest, AddQuestEvent);
        EventManager.TriggerEvent(EventName.AddQuest, new EventArg(new Quest(QuestName.FirstTrial)));
    }

    private void AddQuestEvent(EventArg arg) {

        var quest = arg.Quest;
        quests.Add(quest.Name, quest);

        var button = Instantiate(questNameButtonPrefab, questNamesContainer);
        button.GetComponentInChildren<LocalizedTMPro>().ChangeLocalization(quest.NameKey);
        button.GetComponent<Button>().onClick.AddListener(() => ShowQuestDesciptionButton());

    }

    public void ShowQuestDesciptionButton() {

        var questNameText = GetComponentInChildren<LocalizedTMPro>().LocalizationKey;
        // remove localization prefix
        questNameText = questNameText.Remove(0, 7);
        QuestName questName = (QuestName) Enum.Parse(typeof(QuestName), questNameText);
        questDescription.text = quests[questName].DescriptionKey;

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

        UnityExtensions.SetActiveGameObjectChilds(mainPageChilds);
        UnityExtensions.SetActiveGameObjectChilds(questPageChilds);

        backButton.SetActive(gameObject.activeSelf);
    }

    public void BackButton() {

        UnityExtensions.SetActiveGameObjectChilds(questPageChilds);
        UnityExtensions.SetActiveGameObjectChilds(mainPageChilds);

        backButton.SetActive(!gameObject.activeSelf);
    }
    /// <summary>
    /// Open lore page
    /// </summary>
    public void OpenLorePageButton() {

    }
}
