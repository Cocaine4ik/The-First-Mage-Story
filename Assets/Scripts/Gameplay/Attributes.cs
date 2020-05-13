﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    #region Fields

    [Header("Experience and Levels: ")]
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int expToReachLevel;
    [SerializeField] private int currentLevel = 1;
     private int nextLevel;

    [Header("Skills: ")]
    [SerializeField] private int knowledge = 10; // Atack and spell damage + Wizard spells access
    [SerializeField] private int wisdom = 10; // Max mana + Druid spells access
    [SerializeField] private int spirit = 10; // Max health + Monk spells acess
    [SerializeField] private int faith = 10; // Change to create a miracle and miracle power + Priest spells acess

    [SerializeField] private int skillPoints = 0;

    public static Attributes Instance;

    #endregion

    #region Properties

    public int CurrentExp => currentExp;
    public int ExpToReachLevel => expToReachLevel;
    public int CurrentLevel => currentLevel;
    public int NextLevel => nextLevel;

    public int Knowledge => knowledge;
    public int Wisdom => wisdom;
    public int Spirit => spirit;
    public int Faith => faith;

    #endregion

    #region Methods

    public void IncreaseSkill(int skill) {
        skill++;
    }
    /*
    private void Start() {

        EventManager.StartListening(EventName.AddExp, OnAddExp);

    }

    private void OnDestroy() {
        EventManager.StopListening(EventName.AddExp, OnAddExp);
    }
    */
    /*
    private void OnAddExp(EventArg arg)
    {
        currentExp += arg.FirstIntArg;
        ChangeExpValue(arg.FirstIntArg);

        if (currentExp >= expToReachLevel)
        {
            LevelUp();
        }

    }*/
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
