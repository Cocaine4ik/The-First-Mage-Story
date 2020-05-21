using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterMenu : UIElementBase
{
    [Header("Character Values:")]
    [SerializeField] private TextMeshProUGUI healthValue;
    [SerializeField] private TextMeshProUGUI manaValue;
    [SerializeField] private TextMeshProUGUI knowledgeValue;
    [SerializeField] private TextMeshProUGUI wisdomValue;
    [SerializeField] private TextMeshProUGUI spiritValue;
    [SerializeField] private TextMeshProUGUI faithValue;
    [SerializeField] private TextMeshProUGUI demonsValue;
    [SerializeField] private TextMeshProUGUI alchemyValue;
    [SerializeField] private TextMeshProUGUI levelValue;
    [SerializeField] private TextMeshProUGUI expValue;
    [SerializeField] private LocalizedTMPro rank;
    [SerializeField] private TextMeshProUGUI skillPointsValue;

    [Header("SkillsButtons:")]
    [SerializeField] private Button increaseKnowledgeButton;
    [SerializeField] private Button increaseWisdomButton;
    [SerializeField] private Button increaseSpiritButton;
    [SerializeField] private Button increaseFaithButton;
    [SerializeField] private Button decreaseKnowledgeButton;
    [SerializeField] private Button decreaseWisdomButton;
    [SerializeField] private Button decreaseSpiritButton;
    [SerializeField] private Button decreaseFaithButton;

    private GameObject player;
    private CharacterHealth characterHealth;
    private CharacterMana characterMana;

    private const string rankDefaultKey = "UI.CharacterMenu.Rank.";

    private int cashKnowledgeValue;
    private int cashWisdomValue;
    private int cashSpiritValue;
    private int cashFaithValue;

    private void OnEnable() {
        EventManager.StartListening(EventName.RefreshCharacterMenuValues, OnRefreshCharacterMenuValues);
        EventManager.StartListening(EventName.SaveCharacterMenuCash, OnSaveCharacterMenuCash);
    }

    private void OnDisable() {
        EventManager.StopListening(EventName.RefreshCharacterMenuValues, OnRefreshCharacterMenuValues);
        EventManager.StopListening(EventName.SaveCharacterMenuCash, OnSaveCharacterMenuCash);
    }

    protected override void Start() {

        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        characterHealth = player.GetComponent<CharacterHealth>();
        characterMana = player.GetComponent<CharacterMana>();

        increaseKnowledgeButton.onClick.AddListener(() => Attributes.Instance.ChangeKnowledge(isIncrease: true));
        increaseWisdomButton.onClick.AddListener(() => Attributes.Instance.ChangeWisdom(isIncrease: true));
        increaseSpiritButton.onClick.AddListener(() => Attributes.Instance.ChangeSpirit(isIncrease: true));
        increaseFaithButton.onClick.AddListener(() => Attributes.Instance.ChangeFaith(isIncrease: true));

        decreaseKnowledgeButton.onClick.AddListener(() => Attributes.Instance.ChangeKnowledge(isIncrease: false));
        decreaseWisdomButton.onClick.AddListener(() => Attributes.Instance.ChangeWisdom(isIncrease: false));
        decreaseSpiritButton.onClick.AddListener(() => Attributes.Instance.ChangeSpirit(isIncrease: false));
        decreaseFaithButton.onClick.AddListener(() => Attributes.Instance.ChangeFaith(isIncrease: false));

    }

    private void RefreshStatValue(int maxValue, int currentValue, TextMeshProUGUI textValue) {

        textValue.text = maxValue + "/" + currentValue;
    }

    private void RefreshAttributesValues() {

        knowledgeValue.text = Attributes.Instance.Knowledge.ToString();
        wisdomValue.text = Attributes.Instance.Wisdom.ToString();
        spiritValue.text = Attributes.Instance.Spirit.ToString();
        faithValue.text = Attributes.Instance.Faith.ToString();
        demonsValue.text = Attributes.Instance.Demons.ToString();
        alchemyValue.text = Attributes.Instance.Alchemy.ToString();
        levelValue.text = Attributes.Instance.CurrentLevel.ToString();
        expValue.text = Attributes.Instance.CurrentExp + "/" + Attributes.Instance.ExpToLevelUp;
        rank.ChangeLocalization(rankDefaultKey + levelValue.text);
        skillPointsValue.text = Attributes.Instance.SkillPoints.ToString();

    }
    private void OnRefreshCharacterMenuValues(EventArg arg) {

        RefreshStatValue(characterHealth.MaxHealth, characterHealth.CurrentHealth, healthValue);
        RefreshStatValue(characterMana.MaxMana, characterMana.CurrentMana, manaValue);
        RefreshAttributesValues();
        SetActiveButtons();
    }
    private void OnSaveCharacterMenuCash(EventArg arg) {

        cashKnowledgeValue = Attributes.Instance.Knowledge;
        cashWisdomValue = Attributes.Instance.Wisdom;
        cashSpiritValue = Attributes.Instance.Spirit;
        cashFaithValue = Attributes.Instance.Faith;

        SetActiveButtons();
    }

    private void SetActiveButtons() {

        SetActiveDecreaseButton(Attributes.Instance.Knowledge, cashKnowledgeValue, decreaseKnowledgeButton);
        SetActiveDecreaseButton(Attributes.Instance.Wisdom, cashWisdomValue, decreaseWisdomButton);
        SetActiveDecreaseButton(Attributes.Instance.Spirit, cashSpiritValue, decreaseSpiritButton);
        SetActiveDecreaseButton(Attributes.Instance.Faith, cashFaithValue, decreaseFaithButton);
        SetActiveIncreaseButton(increaseKnowledgeButton);
        SetActiveIncreaseButton(increaseWisdomButton);
        SetActiveIncreaseButton(increaseSpiritButton);
        SetActiveIncreaseButton(increaseFaithButton);

    }

    private void SetActiveDecreaseButton(int skill, int cashSkill, Button button) {
        if (skill > cashSkill) button.gameObject.SetActive(true);
        else button.gameObject.SetActive(false);
    }
    private void SetActiveIncreaseButton(Button button) {
        if (Attributes.Instance.SkillPoints > 0) button.gameObject.SetActive(true);
        else button.gameObject.SetActive(false);
    }
}
