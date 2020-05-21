using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMana : MonoBehaviour
{
    [SerializeField] private int maxMana;
    [SerializeField] private int currentMana;

    public int MaxMana => maxMana;
    public int CurrentMana => currentMana;

    private void Awake() {

        currentMana = maxMana;
    }

    public void BurnMana(int burnedMana) {

        currentMana -= burnedMana;
    }

    public void SetMaxMana(int value) {
        maxMana = value;
        var manaPercent = (float)currentMana / maxMana;
        EventManager.TriggerEvent(EventName.SetMaxMana, new EventArg(manaPercent));
    }
}
