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
        EventManager.StartListening(EventName.AddExp, OnAddExp);

        expBar.fillAmount = 0.0f;

    }

    private void OnDestroy() {

        EventManager.StopListening(EventName.LevelUp, OnLevelUp);
        EventManager.StopListening(EventName.AddExp, OnAddExp);

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void OnAddExp(EventArg arg) {
        

    }

    private void OnLevelUp(EventArg arg)
    {
        Debug.Log("Level: " + arg.FirstIntArg);
        Debug.Log("ExpForLevel: " + arg.SecondIntArg);
        expBar.fillAmount = 0.0f;
    }

}
