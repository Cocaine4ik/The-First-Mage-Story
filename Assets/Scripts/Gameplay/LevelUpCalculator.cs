using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelUpCalculator : MonoBehaviour
{
    #region Fields

    [SerializeField] private int currentExp;
    [SerializeField] private int expToReachLevel;
    [SerializeField] private int currentLevel;

    #endregion

    #region Properties

    public int CurrentExp { get { return currentExp; } }
    public int ExpToReachLevel { get { return expToReachLevel; } }
    public int CurrentLevel { get { return CurrentLevel; } }

    #endregion
    #region Methods

    private void Start()
    {
        EventManager.StartListening(EventName.AddExp, OnAddExp);

    }

    private void OnDestroy()
    {
        EventManager.StopListening(EventName.AddExp, OnAddExp);
    }

    /// <summary>
    /// if experince >= experience to reach level trigget level up event
    /// </summary>
    private void LevelUp()  {

        currentLevel += 1;

        int previousLevelMaxExp = expToReachLevel;

        SetExpToReachLevel(currentLevel);
        EventManager.TriggerEvent(EventName.LevelUp, new EventArg(currentLevel));
        ChangeExpValue(currentExp - previousLevelMaxExp);
    }
    
    /// <summary>
    /// set expt to reach next level
    /// </summary>
    /// <param name="lvl"></param>
    private void SetExpToReachLevel(int lvl)
    {
        switch(lvl)
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

    private void OnAddExp(EventArg arg)
    {
        currentExp += arg.FirstIntArg;
        ChangeExpValue(arg.FirstIntArg);

        if (currentExp >= expToReachLevel)
        {
            LevelUp();
        }

    }

    private void ChangeExpValue(int exp)
    {

        float expPercent = (float)exp/ expToReachLevel;
        Debug.Log("Exp added: " + exp + " Exp: " + currentExp + " ExpToReach " + expToReachLevel + " " + expPercent);

        EventManager.TriggerEvent(EventName.GUIExpChange, new EventArg(expPercent));
    }
    #endregion
}
