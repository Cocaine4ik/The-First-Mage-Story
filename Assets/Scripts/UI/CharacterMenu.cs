using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMenu : UIElementBase
{
    [SerializeField] private TextMeshProUGUI healthValue;
    [SerializeField] private TextMeshProUGUI manaValue;

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

    private void OnRefreshCharacterMenuValues(EventArg arg) {

        RefreshStatValue(characterHealth.MaxHealth, characterHealth.CurrentHealth, healthValue);
        RefreshStatValue(characterMana.MaxMana, characterMana.CurrentMana, manaValue);
    }

}
