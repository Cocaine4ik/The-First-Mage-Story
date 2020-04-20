using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene director
/// </summary>
public class SceneDirector : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer playerSprite;
    private bool appearFlag = false;
    [SerializeField] private float alphaPerFrame;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        EventManager.StartListening(EventName.AppearPlayer, OnAppearPlayer);
    }
    private void Update() {
        if(appearFlag == true) {
            AppearPlayer(alphaPerFrame);
        }
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.AppearPlayer, OnAppearPlayer);
    }

    private void OnAppearPlayer(EventArg arg) {
        appearFlag = true;
    }

    private void AppearPlayer(float alphaPerFrame) {

        var tempColor = playerSprite.color;
        tempColor.a += alphaPerFrame;
        playerSprite.color = tempColor;
    }
}
