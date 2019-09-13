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

    private float[] position;
    #endregion

    #region Constructor
    ///
    public PlayerData(GameObject player) {

        if (player != null) {
            Player playerMain = player.GetComponent<Player>();
            LevelUpCalculator playerExp = player.GetComponent<LevelUpCalculator>();

            level = playerExp.CurrentExp;
            exp = playerExp.CurrentExp;
            expToReachLevel = playerExp.ExpToReachLevel;

            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;

            hp = playerMain.Hp;
            
        }

        else {
            Debug.Log("Critical Error! Player gameobject is missing!");
        }
    }

    #endregion
}
