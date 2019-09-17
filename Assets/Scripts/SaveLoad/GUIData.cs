using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GUIData
{

    #region Feilds

    private float hpAmount;
    private float manaAmount;
    private float expAmount;

    #endregion

    #region Properties

    public float HpAmount { get { return hpAmount; } }
    public float ManaAmount { get { return manaAmount; } }
    public float ExpAmount { get { return expAmount; } }

    #endregion

    #region Constructor

    public GUIData(GUI gameUserInterface) {

        this.hpAmount = gameUserInterface.HpBar.fillAmount;
        this.manaAmount = gameUserInterface.ManaBar.fillAmount;
        this.expAmount = gameUserInterface.ExpBar.fillAmount;

    }
    #endregion

}
