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

    private void OnEnable() {

        EventManager.StartListening(EventName.LevelUp, OnLevelUp);
        EventManager.StartListening(EventName.GUIExpChange, OnGUIExpChange);
        EventManager.StartListening(EventName.ManaChange, OnGUIManaChange);
        EventManager.StartListening(EventName.HpChange, OnGUIHealthChange);
        EventManager.StartListening(EventName.SetMaxHp, OnSetMaxHealth);
        EventManager.StartListening(EventName.SetMaxMana, OnSetMaxMana);

    }
    void Start () {

        expBar.fillAmount = 0.0f;

    }

    private void OnDisable() {

        EventManager.StopListening(EventName.LevelUp, OnLevelUp);
        EventManager.StopListening(EventName.GUIExpChange, OnGUIExpChange);
        EventManager.StopListening(EventName.ManaChange, OnGUIManaChange);
        EventManager.StopListening(EventName.HpChange, OnGUIHealthChange);
        EventManager.StopListening(EventName.SetMaxMana, OnSetMaxMana);

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void OnGUIExpChange(EventArg arg) {
        expBar.fillAmount =+ arg.FirstFloatArg;

    }

    public void OnGUIManaChange(EventArg arg)
    {
        manaBar.fillAmount -= arg.FirstFloatArg;
    }

    public void OnGUIHealthChange (EventArg arg) {

        hpBar.fillAmount -= arg.FirstFloatArg;

    }
    public void OnSetMaxHealth(EventArg arg) {
        hpBar.fillAmount = arg.FirstFloatArg;
    }
    public void OnSetMaxMana(EventArg arg) {
        manaBar.fillAmount = arg.FirstFloatArg;
    }
    private void OnLevelUp(EventArg arg)
    {
        lvlLabel.text = arg.FirstIntArg.ToString();
        expBar.fillAmount = 0.0f;
    }

}
