using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPanel : MonoBehaviour
{
    [SerializeField] private List<SpellInvoker> spellInvokers;
    private List<ActionPanelCell> panelCells = new List<ActionPanelCell>();

    private void OnEnable() {
        EventManager.StartListening(EventName.AddSpelltoPanelCell, OnAddSpell);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.AddSpelltoPanelCell, OnAddSpell);
    }

    private void Start() {
        foreach(SpellInvoker spellInvoker in spellInvokers) {
            var panelCell = spellInvoker.gameObject.GetComponent<ActionPanelCell>();
            panelCells.Add(panelCell);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("[1] Action Panel Cell")) {
            spellInvokers[1].InvokeSpell();
        }
        if (Input.GetButtonDown("[2] Action Panel Cell")) {
            spellInvokers[2].InvokeSpell();
        }
        if (Input.GetButtonDown("[3] Action Panel Cell")) {
            spellInvokers[3].InvokeSpell();
        }
        if (Input.GetButtonDown("[4] Action Panel Cell")) {
            spellInvokers[4].InvokeSpell();
        }
        if (Input.GetButtonDown("[5] Action Panel Cell")) {
            spellInvokers[5].InvokeSpell();
        }
        if (Input.GetButtonDown("[6] Action Panel Cell")) {
            spellInvokers[6].InvokeSpell();
        }
        if (Input.GetButtonDown("[7] Action Panel Cell")) {
            spellInvokers[7].InvokeSpell();
        }
        if (Input.GetButtonDown("[8] Action Panel Cell")) {
            spellInvokers[8].InvokeSpell();
        }
        if (Input.GetButtonDown("[9] Action Panel Cell")) {
            spellInvokers[9].InvokeSpell();
        }
        if (Input.GetButtonDown("[0] Action Panel Cell")) {
            spellInvokers[0].InvokeSpell();
        }

    }

    private void OnAddSpell(EventArg arg) {

        var id = arg.FirstIntArg;
        var icon = arg.Sprite;
        var spell = arg.Spell;

        foreach(ActionPanelCell cell in panelCells) {

            if(cell.Id == id) {
                cell.Image.sprite = icon;
                cell.SpellInvoker.Spell = spell;
            }
        }
    }
}
