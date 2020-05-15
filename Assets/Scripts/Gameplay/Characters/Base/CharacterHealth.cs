using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;


    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    private void Awake() {

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {

        // if current health > damage we dont play hurt animation and play only death animation
        if(currentHealth > damage) {
            GetComponentInParent<Character>().Hurt();
        }

        currentHealth -= damage;
        
        if(GetComponent<Player>() != null) {

            float healthPercent = (float)damage / maxHealth;
            EventManager.TriggerEvent(EventName.HpChange, new EventArg(healthPercent));
        }

    }

    public void SetMaxHealth(int value) {
        maxHealth = value;
    }
}
