using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using VIDE_Data;
public class DialogueSystem : Singleton<DialogueSystem>
{
    private DialogueWindow dialogueWindow; // UI options

    private void Start()
    {
        dialogueWindow = GetComponent<DialogueWindow>();
    }

    public void Interact(VIDE_Assign dialogue)
    {
        if (!VD.isActive) Begin(dialogue);
        else VD.Next();
    }

    private void Begin(VIDE_Assign dialogue)
    {
        //Let's reset the NPC text variables
        dialogueWindow.NPC_Text.text = "";
        dialogueWindow.NPC_Label.text = "";
        dialogueWindow.PlayerLabel.text = "";

        //First step is to call BeginDialogue, passing the required VIDE_Assign component 
        //This will store the first Node data in VD.nodeData
        //But before we do so, let's subscribe to certain events that will allow us to easily
        //Handle the node-changes
        VD.OnActionNode += ActionHandler;
        VD.OnNodeChange += dialogueWindow.UpdateUI;
        VD.OnEnd += EndDialogue;

        VD.BeginDialogue(dialogue); //Begins dialogue, will call the first OnNodeChange

        dialogueWindow.DialogueContainer.SetActive(true); //Let's make our dialogue container visible
    }

    //Unsuscribe from everything, disable UI, and end dialogue
    //Called automatically because we subscribed to the OnEnd event
    void EndDialogue(VD.NodeData data)
    {
        VD.OnActionNode -= ActionHandler;
        VD.OnNodeChange -= dialogueWindow.UpdateUI;
        VD.OnEnd -= EndDialogue;
        dialogueWindow.DialogueContainer.SetActive(false);
        VD.EndDialogue();

        VD.SaveState("VIDEDEMOScene1", true); //Saves VIDE stuff related to EVs and override start nodes
        
    }
    void OnDisable()
    {
        //If the script gets destroyed, let's make sure we force-end the dialogue to prevent errors
        VD.OnActionNode -= ActionHandler;
        VD.OnNodeChange -= dialogueWindow.UpdateUI;
        VD.OnEnd -= EndDialogue;
        if (dialogueWindow.DialogueContainer != null)
            dialogueWindow.DialogueContainer.SetActive(false);
        VD.EndDialogue();
    }
    #region EVENTS AND HANDLERS

    //Just so we know when we finished loading all dialogues, then we unsubscribe
    void OnLoadedAction()
    {
        Debug.Log("Finished loading all dialogues");
        VD.OnLoaded -= OnLoadedAction;
    }

    //Another way to handle Action Nodes is to listen to the OnActionNode event, which sends the ID of the action node
    void ActionHandler(int actionNodeID)
    {
        //Debug.Log("ACTION TRIGGERED: " + actionNodeID.ToString());
    }

    //Adds item to demo inventory
    private void GiveItem(Item item)
    {
        InventorySystem.Instance.AddItem(item);
    }

    #endregion
    public void AddQuest(QuestName questName)
    {
        QuestSystem.Instance.AddQuest(questName);
    }

    public void SpawnTip(int id)
    {
        EventManager.TriggerEvent(EventName.SpawnTip, new EventArg(id));
    }
}
