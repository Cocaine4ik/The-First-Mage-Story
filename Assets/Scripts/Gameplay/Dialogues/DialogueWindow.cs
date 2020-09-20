using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VIDE_Data;

public class DialogueWindow : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject dialogueContainer;
    [SerializeField] private GameObject nPC_Container;
    [SerializeField] private GameObject playerContainer;

    [SerializeField] private TextMeshProUGUI nPC_Text;
    [SerializeField] private TextMeshProUGUI nPC_label;
    [SerializeField] private Image nPCSprite;
    [SerializeField] private GameObject playerChoicePrefab;
    [SerializeField] private Image playerSprite;
    [SerializeField] private TextMeshProUGUI playerLabel;

    //We'll be using this to store references of the current player choices
    private List<TextMeshProUGUI> currentChoices = new List<TextMeshProUGUI>();

    #endregion

    #region Properties

    public GameObject DialogueContainer => dialogueContainer;
    public GameObject NPC_Container => nPC_Container;
    public GameObject PlayerContainer => playerContainer;

    public TextMeshProUGUI NPC_Text => nPC_Text;
    public TextMeshProUGUI NPC_Label => nPC_label;
    public Image NPCSprite => nPCSprite;
    public GameObject PlayerChoicePrefab => playerChoicePrefab;
    public Image PlayerSprtie => playerSprite;
    public TextMeshProUGUI PlayerLabel => playerLabel;

    #endregion
    public void UpdateUI(VD.NodeData data)
    {
        //Reset some variables
        //Destroy the current choices
        foreach (TextMeshProUGUI op in currentChoices)
            Destroy(op.gameObject);
        currentChoices = new List<TextMeshProUGUI>();
        NPC_Text.text = "";
        NPC_Container.SetActive(false);
        playerContainer.SetActive(false);
        playerSprite.sprite = null;
        NPCSprite.sprite = null;

        //If this new Node is a Player Node, set the player choices offered by the node
        if (data.isPlayer)
        {
            //Set node sprite if there's any, otherwise try to use default sprite
            if (data.sprite != null)
                playerSprite.sprite = data.sprite;
            else if (VD.assigned.defaultPlayerSprite != null)
                playerSprite.sprite = VD.assigned.defaultPlayerSprite;

            SetOptions(data.comments);

            //If it has a tag, show it, otherwise let's use the alias we set in the VIDE Assign
            if (data.tag.Length > 0)
                playerLabel.text = data.tag;

            //Sets the player container on
            playerContainer.SetActive(true);

        }
        else  //If it's an NPC Node, let's just update NPC's text and sprite
        {
            //Set node sprite if there's any, otherwise try to use default sprite
            if (data.sprite != null)
            {
                //For NPC sprite, we'll first check if there's any "sprite" key
                //Such key is being used to apply the sprite only when at a certain comment index
                //Check CrazyCap dialogue for reference
                if (data.extraVars.ContainsKey("sprite"))
                {
                    if (data.commentIndex == (int)data.extraVars["sprite"])
                        NPCSprite.sprite = data.sprite;
                    else
                        NPCSprite.sprite = VD.assigned.defaultNPCSprite; //If not there yet, set default dialogue sprite
                }
                else //Otherwise use the node sprites
                {
                    NPCSprite.sprite = data.sprite;
                }
            } //or use the default sprite if there isnt a node sprite at all
            else if (VD.assigned.defaultNPCSprite != null)
                NPCSprite.sprite = VD.assigned.defaultNPCSprite;

            //If it has a tag, show it, otherwise let's use the alias we set in the VIDE Assign
            if (data.tag.Length > 0)
                nPC_label.text = data.tag;

            //Sets the NPC container on
            NPC_Container.SetActive(true);
        }
    }

    public void SetOptions(string[] choices)
    {
        //Create the choices. The prefab comes from a dummy gameobject in the scene
        //This is a generic way of doing it. You could instead have a fixed number of choices referenced.
        for (int i = 0; i < choices.Length; i++)
        {
            GameObject newOp = Instantiate(playerChoicePrefab.gameObject, playerChoicePrefab.transform.position, Quaternion.identity) as GameObject;
            newOp.transform.SetParent(playerChoicePrefab.transform.parent, true);
            newOp.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 20 - (20 * i));
            newOp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            newOp.GetComponent<TextMeshProUGUI>().text = choices[i];
            newOp.SetActive(true);

            currentChoices.Add(newOp.GetComponent<TextMeshProUGUI>());
        }
    }
}
