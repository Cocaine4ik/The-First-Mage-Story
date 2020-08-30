using JetBrains.Annotations;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCliffsDirector : MonoBehaviour
{
    [SerializeField] private float alphaPerFrame;
    [SerializeField] private GameObject movingPlatform;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wolfDemon;
    [SerializeField] private List<GameObject> veils = new List<GameObject>();
    [SerializeField] private GameObject dialogueTrigger;
    [SerializeField] private GameObject filter;

    private SpriteRenderer playerSprite;
    private bool appearFlag = false;

    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
        EventManager.StartListening(EventName.AppearPlayer, OnAppearPlayer);
        EventManager.StartListening(EventName.PickupItem, OnPickupItem);

        var alpha = playerSprite.color;
        alpha.a = 0;
        playerSprite.color = alpha;
    }
    private void Update()
    {
        if (appearFlag == true)
        {
            AppearPlayer(alphaPerFrame);
        }
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventName.AppearPlayer, OnAppearPlayer);
    }

    private void OnAppearPlayer(EventArg arg)
    {
        appearFlag = true;
    }
    private void OnPickupItem(EventArg arg)
    {
        if (arg.Item.ItemName == ItemName.FlyingStones)
        {
            movingPlatform.GetComponent<MovingPlatform>().MoveUp();
            AudioManager.SFXAudioSource.Play(SFXClipName.PlatformMove);
            EventManager.StopListening(EventName.PickupItem, OnPickupItem);
        }

        if(arg.Item.ItemName == ItemName.RoyalBlueflower && player.transform.position.x > 120f)
        {
            wolfDemon.SetActive(true);
            foreach(GameObject veil in veils)
            {
                veil.SetActive(true);
            }
            dialogueTrigger.SetActive(true);
        }
    }

    private void DemonWolfEnter()
    {

    }
    private void AppearPlayer(float alphaPerFrame)
    {

        if (playerSprite != null)
        {

            var tempColor = playerSprite.color;
            tempColor.a += alphaPerFrame;
            playerSprite.color = tempColor;

            if (playerSprite.color.a > 1)
            {
                appearFlag = false;
                StatusUtils.CutScenePlaying = false;
            }

        }
    }
}
