using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    #region Fields

    [SerializeField] private int currentExp;
    [SerializeField] private int expToReachLevel;
    [SerializeField] private int currentLevel;
    [SerializeField] private int nextLevel;

    [SerializeField] private int maxHp;
    [SerializeField] private int currentHp;

    [SerializeField] private int maxMana;
    [SerializeField] private int currentMana;

    Player player;
    /// <summary>
    /// Hp and magic resistance
    /// </summary>
    [SerializeField] private int spirit;

    /// <summary>
    /// Damage of magic arrows and destruction spells
    /// </summary>
    [SerializeField] private int knowledge;

    /// <summary>
    /// Mana and count of spells in spellbook
    /// </summary>
    [SerializeField] private int wisdom;

    /// <summary>
    /// Dialogues and artefacts slots
    /// </summary>
    [SerializeField] private int personality;

    #endregion

    #region Properties

    public int MaxHp { get { return maxHp; } }
    public int MaxMana { get { return maxMana; } }
    public int CurrentHp{ get { return currentHp; } }
    public int CurrentMana { get { return currentExp; } }
    public int CurrentExp { get { return currentExp; } }
    public int ExpToReachLevel { get { return expToReachLevel; } }
    public int СurrentLevel { get { return currentLevel; } }

    #endregion

    #region Methods

    private void Start() {

        EventManager.StartListening(EventName.AddExp, OnAddExp);

        player = GetComponent<Player>();

        // initialize start hp and mana
        maxHp = ConfigurationUtils.HpDefault;
        maxMana = ConfigurationUtils.ManaDefault;
        currentHp = maxHp;
        currentMana = maxMana;
        /*
        player.Hp = currentHp;
        player.Mana = currentMana;
        */
        SetExpToReachLevel(currentLevel);
        spirit = ConfigurationUtils.SpiritDefault;
        knowledge = ConfigurationUtils.KnowledgeDefault;
        wisdom = ConfigurationUtils.WisdomDefault;
        personality = ConfigurationUtils.PersonalityDefault;

    }

    private void OnDestroy() {
        EventManager.StopListening(EventName.AddExp, OnAddExp);
    }



    public void SetMana(int mana) {
        currentMana = mana;
    }
    public void SetHp(int hp) {
        currentHp = hp;
    }
    public void SavePlayer() {

        SaveSystem.SavePlayer(this.gameObject);
    }

    public void LoadPlayer() {

        PlayerData data = SaveSystem.LoadPlayer();

        currentMana = data.CurrentMana;
        gameObject.transform.position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);

    }

    private void OnAddExp(EventArg arg)
    {
        currentExp += arg.FirstIntArg;
        ChangeExpValue(arg.FirstIntArg);

        if (currentExp >= expToReachLevel)
        {
            LevelUp();
        }

    }
    private void LevelUp()
    {

        currentLevel += 1;

        int previousLevelMaxExp = expToReachLevel;

        SetExpToReachLevel(currentLevel);
        EventManager.TriggerEvent(EventName.LevelUp, new EventArg(currentLevel));
        ChangeExpValue(currentExp - previousLevelMaxExp);
    }

    /// <summary>
    /// Set exp to reach next level
    /// </summary>
    /// <param name="lvl"></param>
    private void SetExpToReachLevel(int lvl)
    {
        switch (lvl)
        {
            case 1: expToReachLevel = ConfigurationUtils.ExpToReachLevelTwo; break;
            case 2: expToReachLevel = ConfigurationUtils.ExpToReachLevelThree; break;
                /*
                case 3: expToReachLevel = ConfigurationUtils.ExpToReachLevelFour; break;
                case 4: break;
                case 5: break;
                case 6: break;
                case 7: break;
                case 8: break;
                case 9: break;
                case 10: break;
                case 11: break;
                case 12: break;
                case 13: break;
                case 14: break;
                case 15: break;
                case 16: break;
                case 17: break;
                case 18: break;
                case 19: break;
                case 20: break;
                */
        }
    }

    private void ChangeExpValue(int exp)
    {

        float expPercent = (float)exp / expToReachLevel;
        EventManager.TriggerEvent(EventName.GUIExpChange, new EventArg(expPercent));
    }
    #endregion
}
