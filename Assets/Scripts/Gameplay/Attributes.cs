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

        player = GetComponent<Player>();

        maxHp = ConfigurationUtils.HpDefault;
        maxMana = ConfigurationUtils.ManaDefault;

        spirit = ConfigurationUtils.SpiritDefault;
        knowledge = ConfigurationUtils.KnowledgeDefault;
        wisdom = ConfigurationUtils.WisdomDefault;
        personality = ConfigurationUtils.PersonalityDefault;

    }

    private void Update() {

        player.Hp = currentHp;
        player.Mana = currentMana;
        
    }

    public void SavePlayer() {

        SaveSystem.SavePlayer(this.gameObject);
    }

    public void LoadPlayer() {

        PlayerData data = SaveSystem.LoadPlayer();

        currentMana = data.CurrentMana;
        gameObject.transform.position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);

    }
    #endregion
}
