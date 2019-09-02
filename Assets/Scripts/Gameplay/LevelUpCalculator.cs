using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCalculator : MonoBehaviour
{
    #region Fields

    [SerializeField] private int currentExp;
    [SerializeField] private int expToReachLevel;
    [SerializeField] private int currentLevel;

    private Player player;

    #endregion

    #region Methods

    private void Start()
    {
        player = GetComponent<Player>();
        currentLevel = player.Lvl;
        currentExp = player.Exp;
        SetExpToReachLevel(currentLevel);
    }

    private void Update()
    {
        LevelUp();
        SetExpToReachLevel(currentLevel);
    }
    /// <summary>
    /// if experince >= experience to reach level trigget level up event
    /// </summary>
    private void LevelUp()
    {
        currentExp = player.Exp;

        if (currentExp >= expToReachLevel)
        {
            EventManager.TriggerEvent(EventName.LevelUp, new EventArg(currentLevel++));
        }
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
        }
    }

    public void AddExp(int expAmount)
    {

        player.SetExp(expAmount);

    }
    #endregion
}
