using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    #region Fields

    private int level;
    private int exp;
    private int expToReachLevel;
    private int hp;
    private int mana;

    private float[] postion;
    #endregion

    #region Constructor
    ///
    public PlayerData(GameObject player) {

        if (player != null) {

            Player playerMain = player.GetComponent<Player>();
            LevelUpCalculator playerExp = player.GetComponent<LevelUpCalculator>();

            level = playerExp.CurrentLevel;
            exp = playerExp.CurrentExp;
            expToReachLevel = playerExp.ExpToReachLevel;

            hp = playerMain.Hp;
            

            postion = new float[3];
            postion[0] = player.transform.position.x;
            postion[1] = player.transform.position.y;
            postion[2] = player.transform.position.z;
        }

        else {
            Debug.Log("Critical Error! Player gameobject is missing!");
        }
    }

    #endregion
}
