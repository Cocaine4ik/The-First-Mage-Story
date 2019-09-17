using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUI : MonoBehaviour {

    #region Fields

    [SerializeField] private Image hpBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image expBar;
    [SerializeField] private TextMeshProUGUI lvlLabel;

    #endregion

    #region Properties

    public Image HpBar { get { return hpBar; } }
    public Image ManaBar { get { return manaBar; } }
    public Image ExpBar { get { return expBar; } }
    public TextMeshProUGUI LvlLabel { get { return lvlLabel; } }

    #endregion
    // Use this for initialization
    void Start () {

        EventManager.StartListening(EventName.LevelUp, OnLevelUp);
        EventManager.StartListening(EventName.GUIExpChange, OnGUIExpChange);
        EventManager.StartListening(EventName.ManaChange, OnGUIManaChange);

        expBar.fillAmount = 0.0f;

    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.LevelUp, OnLevelUp);
        EventManager.StopListening(EventName.GUIExpChange, OnGUIExpChange);
        EventManager.StopListening(EventName.ManaChange, OnGUIManaChange);

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void OnGUIExpChange(EventArg arg) {

        expBar.fillAmount += arg.FirstFloatArg;

    }

    public void OnGUIManaChange(EventArg arg)
    {
        manaBar.fillAmount -= arg.FirstFloatArg;
    }
    private void OnLevelUp(EventArg arg)
    {
        lvlLabel.text = "lvl: " + arg.FirstIntArg;
        expBar.fillAmount = 0.0f;
    }

}
