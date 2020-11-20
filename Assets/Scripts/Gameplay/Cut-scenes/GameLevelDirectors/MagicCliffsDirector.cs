using JetBrains.Annotations;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MagicCliffsDirector : MonoBehaviour
{
    [SerializeField] private float alphaPerFrame;
    [SerializeField] private GameObject movingPlatform;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wolfDemon;
    [SerializeField] private List<GameObject> veils = new List<GameObject>();
    [SerializeField] private GameObject firstDialogue;
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

        wolfDemon.SetActive(false);
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

    }

    public void DemonWolfEnter()
    {
        Debug.Log("Demon wolf enter");
        wolfDemon.SetActive(true);
        player.GetComponent<Player>().Flip(-2);
        foreach (GameObject veil in veils)
        {
            veil.SetActive(true);
        }
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
                if (firstDialogue != null) firstDialogue.SetActive(true);

            }
        }
    }

    public void SetToEnemy(Character character)
    {
        Debug.Log("SET TO ENEMY");
        var npcLayer = LayerMask.NameToLayer("NPC");
        var playerLayer = LayerMask.NameToLayer("Player");

        character.Enemies = new LayerMask();

        character.Enemies += npcLayer;
        character.Enemies += playerLayer;
    }
    public void SetToNPC()
    {

    }
    public void SetToPassive()
    {

    }
}
