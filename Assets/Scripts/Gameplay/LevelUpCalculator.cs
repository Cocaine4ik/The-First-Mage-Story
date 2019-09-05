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

    #region Methods

    private void Start()
    {
        EventManager.StartListening(EventName.AddExp, OnAddExp);

    }

    private void OnDestroy()
    {
        EventManager.StopListening(EventName.AddExp, OnAddExp);
    }
    private void Update()
    {
        if (currentExp >= expToReachLevel)
        {
            LevelUp();
        }


    }
    /// <summary>
    /// if experince >= experience to reach level trigget level up event
    /// </summary>
    private void LevelUp()
    {
            currentLevel += 1;
            SetExpToReachLevel(currentLevel);
            EventManager.TriggerEvent(EventName.LevelUp, new EventArg());
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
        float expPercent = arg.FirstIntArg / expToReachLevel;
        Debug.Log("Exp added: " + arg.FirstIntArg + " Exp: " + currentExp + " " + expPercent);
        EventManager.TriggerEvent(EventName.GUIExpChange, new EventArg(expPercent));
    }

    #endregion
}
