using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene director
/// </summary>
public class SceneDirector : MonoBehaviour
{
    [SerializeField] private float alphaPerFrame;
    [SerializeField] private GameObject movingPlatform;

    private GameObject player;
    private SpriteRenderer playerSprite;
    private bool appearFlag = false;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        EventManager.StartListening(EventName.AppearPlayer, OnAppearPlayer);
        EventManager.StartListening(EventName.PickupItem, OnPlatformUp);
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
    private void OnPlatformUp(EventArg arg) {
        if(arg.Item.name == "FlyingStones") {
            movingPlatform.GetComponent<MovingPlatform>().MoveUp();
            AudioManager.SFXAudioSource.Play(SFXClipName.PlatformMove);
            EventManager.StopListening(EventName.PickupItem, OnPlatformUp);
        }
    }
    private void AppearPlayer(float alphaPerFrame) {

        if(playerSprite != null) {
        
        var tempColor = playerSprite.color;
        tempColor.a += alphaPerFrame;
        playerSprite.color = tempColor;

            if(playerSprite.color.a > 1) {
                appearFlag = false;
                StatusUtils.CutScenePlaying = false;
            }

        }
    }
}
