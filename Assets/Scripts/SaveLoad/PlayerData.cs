using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData {

    #region Fields

    private int level;
    private int exp;
    private int expToReachLevel;
    private int maxHp;
    private int currentHp;
    private int maxMana;
    private int currentMana;

    private float[] position;
    #endregion

    #region Properties

    public int Level { get { return level; } }
    public int Exp{ get { return exp; } }
    public int ExpToReachLevel { get { return expToReachLevel; } }
    public int MaxHp { get { return maxHp; } }
    public int CurrentHp { get { return currentHp; } }
    public int MaxMana { get { return maxMana; } }
    public int CurrentMana { get { return currentHp; } }
    public float[] Position { get { return position; } }

    #endregion

    #region Constructor
    public PlayerData(GameObject player) {

        if (player != null) {
            Attributes stats = player.GetComponent<Attributes>();

            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
            /*
            maxHp = stats.MaxHp;
            currentHp = stats.CurrentHp;
            maxMana = stats.MaxMana;
            currentMana = stats.CurrentMana;
            */
        }

        else {
            Debug.Log("Critical Error! Player gameobject is missing!");
        }
    }

    #endregion
}
