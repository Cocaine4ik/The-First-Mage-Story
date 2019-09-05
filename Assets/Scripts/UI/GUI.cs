using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

    [SerializeField] private Image hpBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image expBar;

    // Use this for initialization
    void Start () {

        EventManager.StartListening(EventName.LevelUp, OnLevelUp);
        EventManager.StartListening(EventName.GUIExpChange, OnGUIExpChange);

        expBar.fillAmount = 0.0f;

    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.LevelUp, OnLevelUp);
        EventManager.StopListening(EventName.GUIExpChange, OnGUIExpChange);

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void OnGUIExpChange(EventArg arg) {

        expBar.fillAmount = arg.FirstFloatArg;

    }

    private void OnLevelUp(EventArg arg)
    {
        Debug.Log("Level: " + arg.FirstIntArg);
        Debug.Log("ExpForLevel: " + arg.SecondIntArg);
        expBar.fillAmount = 0.0f;
    }

}
