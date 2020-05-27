using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    #region Fields

    [Header("Experience and Levels: ")]
    [SerializeField] private int currentExp;
    [SerializeField] private int expToLevelUp;
    [SerializeField] private int currentLevel;
    private const int MaxLvl = 20;
    private int previousLevelExp;

    [Header("Skills: ")]
    [SerializeField] private int knowledge; // Atack and spell damage + Wizard spells access
    [SerializeField] private int wisdom; // Max mana + Druid spells access
    [SerializeField] private int spirit; // Max health + Monk spells acess
    [SerializeField] private int faith; // Change to create a miracle and miracle power + Priest spells acess
    [SerializeField] private int demons;
    [SerializeField] private int alchemy;

    [SerializeField] private int skillPoints = 0;

    public static Attributes Instance;

    private CharacterHealth characterHealth;
    private CharacterMana characterMana;

    private float miracleChance;

    #endregion

    #region Properties

    public int CurrentExp => currentExp;
    public int ExpToLevelUp => expToLevelUp;
    public int CurrentLevel => currentLevel;

    public int Knowledge => knowledge;
    public int Wisdom => wisdom;
    public int Spirit => spirit;
    public int Faith => faith;
    public int Demons => demons;
    public int Alchemy => alchemy;

    public int SkillPoints => skillPoints;
    public float MiracleChance => miracleChance;
    #endregion

    #region Methods

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {

            Destroy(gameObject);
        }
    }
    private void Start() {

        characterHealth = GetComponent<CharacterHealth>();
        characterMana = GetComponent<CharacterMana>();

        SetExpToLevelUp(currentLevel);

        // initialize default attributes values
        knowledge = ConfigurationUtils.KnowledgeDefault;
        wisdom = ConfigurationUtils.WisdomDefault;
        spirit = ConfigurationUtils.SpiritDefault;
        faith = ConfigurationUtils.FaithDefault;
        demons = ConfigurationUtils.DemonsDefault;
        alchemy = ConfigurationUtils.AlchemyDefault;

        miracleChance = (float)faith / ConfigurationUtils.FaithChanceModifier;
    }

    private void OnEnable() {
        EventManager.StartListening(EventName.AddExp, OnAddExp);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.AddExp, OnAddExp);
    }

    public void ChangeSpirit(bool isIncrease) {
        spirit = IncreaseSkill(spirit, isIncrease);
        characterHealth.SetMaxHealth(spirit * ConfigurationUtils.HealthBySpiritPoint);
        EventManager.TriggerEvent(EventName.RefreshCharacterMenuValues);
    }
    public void ChangeWisdom(bool isIncrease) {
        wisdom = IncreaseSkill(wisdom, isIncrease);
        characterMana.SetMaxMana(wisdom * ConfigurationUtils.ManaByWisdomPoint);
        EventManager.TriggerEvent(EventName.RefreshCharacterMenuValues);
    }
    public void ChangeKnowledge(bool isIncrease) {
        knowledge = IncreaseSkill(knowledge, isIncrease);
        EventManager.TriggerEvent(EventName.RefreshCharacterMenuValues);
    }
    public void ChangeFaith(bool isIncrease) {
        faith = IncreaseSkill(faith, isIncrease);
        miracleChance = faith / ConfigurationUtils.FaithChanceModifier;
        EventManager.TriggerEvent(EventName.RefreshCharacterMenuValues);

    }
    public void IncreaseDemons() {

    }
    public void IncreaseScience() {

    }

    private int IncreaseSkill(int skillValue, bool isIncrease) {

        if(isIncrease == true) {
            if(skillPoints > 0) {
                skillValue++;
            }
        skillPoints--;
        }
        else if(isIncrease == false) {
            skillValue--;
            skillPoints++;
        }
        return skillValue;
    }
    private void LevelUp()
    {
        if(currentLevel != 20) {
            previousLevelExp = expToLevelUp;
            currentLevel += 1;
            SetExpToLevelUp(currentLevel);
            skillPoints += ConfigurationUtils.SkillPointsPerLevel;
            EventManager.TriggerEvent(EventName.LevelUp, new EventArg(currentLevel));
        }
    }

    /// <summary>
    /// Set exp to reach next level
    /// </summary>
    /// <param name="lvl"></param>
    private void SetExpToLevelUp(int lvl)
    {
        switch (lvl)
        {
            case 1: expToLevelUp = ConfigurationUtils.ExpToLevelTwo; break;
            case 2: expToLevelUp = ConfigurationUtils.ExpToLevelThree; break;
            case 3: expToLevelUp = ConfigurationUtils.ExpToLevelFour; break;
            case 4: expToLevelUp = ConfigurationUtils.ExpToLevelFive; break;
            case 5: expToLevelUp = ConfigurationUtils.ExpToLevelSix; break;
            case 6: expToLevelUp = ConfigurationUtils.ExpToLevelSeven; break;
            case 7: expToLevelUp = ConfigurationUtils.ExpToLevelEight; break;
            case 8: expToLevelUp = ConfigurationUtils.ExpToLevelNine; break;
            case 9: expToLevelUp = ConfigurationUtils.ExpToLevelTen; break;
            case 10: expToLevelUp = ConfigurationUtils.ExpToLevelEleven; break;
            case 11: expToLevelUp = ConfigurationUtils.ExpToLevelTwelve; break;
            case 12: expToLevelUp = ConfigurationUtils.ExpToLevelThirteen; break;
            case 13: expToLevelUp = ConfigurationUtils.ExpToLevelFourteen;break;
            case 14: expToLevelUp = ConfigurationUtils.ExpToLevelFifteen; break;
            case 15: expToLevelUp = ConfigurationUtils.ExpToLevelSixteen; break;
            case 16: expToLevelUp = ConfigurationUtils.ExpToLevelSeventeen; break;
            case 17: expToLevelUp = ConfigurationUtils.ExpToLevelEighteen; break;
            case 18: expToLevelUp = ConfigurationUtils.ExpToLevelNineteen; break;
            case 19: expToLevelUp = ConfigurationUtils.ExpToLevelTwenty; break;
        }
    }
    private void OnAddExp(EventArg arg) {

        currentExp += arg.FirstIntArg;

        if (currentExp >= expToLevelUp) {
            LevelUp();
        }

        var expDifference = currentExp - previousLevelExp;

        ChangeGUIExpValue(expDifference);
    }

    private void ChangeGUIExpValue(int exp)
    {
        var expToLevelDifference = expToLevelUp - previousLevelExp;
        var expPercent = (float)exp / expToLevelDifference;
        Debug.Log("Exp: " + exp + " ExpPercent: " + expPercent + " ExpDif: " + expToLevelDifference);
        EventManager.TriggerEvent(EventName.GUIExpChange, new EventArg(expPercent));
    }
    #endregion
}
