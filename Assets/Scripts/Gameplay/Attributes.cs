using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    #region Fields

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

    #region Methods

    private void Awake() {
        spirit = ConfigurationUtils.SpiritDefault;

    }

    #endregion
}
