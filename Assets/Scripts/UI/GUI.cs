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
        EventManager.StartListening(EventName.ExpChange, GUIPlayerExpChange);
    }

    private void OnDestroy() {
        EventManager.StopListening(EventName.ExpChange, GUIPlayerExpChange);
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void GUIPlayerExpChange(EventArg arg) {
        expBar.fillAmount = 0.1f;
    }


}
