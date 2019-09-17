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
    private int currentHp;
    private int mana;
    private int currentMana;

    private float[] position;
    #endregion

    #region Properties

    public int Level { get { return level; } }
    public int Exp{ get { return exp; } }
    public int ExpToReachLevel { get { return expToReachLevel; } }
    public int Hp { get { return hp; } }
    public int CurrentHp { get { return currentHp; } }
    public int Mana { get { return mana; } }
    public int CurrentMana { get { return currentHp; } }
    public float[] Position { get { return position; } }

    #endregion

    #region Constructor
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
            currentHp = playerMain.CurrentHp;
            mana = playerMain.Mana;
            currentMana = playerMain.CurrentMana;
            
        }

        else {
            Debug.Log("Critical Error! Player gameobject is missing!");
        }
    }

    #endregion
}
