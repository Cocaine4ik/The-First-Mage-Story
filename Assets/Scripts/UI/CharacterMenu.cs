using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMenu : UIElementBase
{
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

    private GameObject player;
    private CharacterHealth characterHealth;
    private CharacterMana characterMana;

    protected override void Start() {

        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        characterHealth = player.GetComponent<CharacterHealth>();
        characterMana = player.GetComponent<CharacterMana>();

        EventManager.StartListening(EventName.RefreshCharacterMenuValues, OnRefreshCharacterMenuValues);
    }
    private void OnDestroy() {
        EventManager.StopListening(EventName.RefreshCharacterMenuValues, OnRefreshCharacterMenuValues);
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
       // alchemyValue.text = Attributes.Instance.Alchemy.ToString();
       // levelValue.text = Attributes.Instance.CurrentLevel.ToString();

    }
    private void OnRefreshCharacterMenuValues(EventArg arg) {

        RefreshStatValue(characterHealth.MaxHealth, characterHealth.CurrentHealth, healthValue);
        RefreshStatValue(characterMana.MaxMana, characterMana.CurrentMana, manaValue);
        RefreshAttributesValues();
    }

}
