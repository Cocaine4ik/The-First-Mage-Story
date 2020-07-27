using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppplyPanel : MonoBehaviour
{
    [SerializeField] private List<SupplyInvoker> spellInvokers;
    private List<SpellPanelCell> panelCells = new List<SpellPanelCell>();

    private void OnEnable()
    {
        EventManager.StartListening(EventName.AddSpelltoPanelCell, OnAddSpell);
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventName.AddSpelltoPanelCell, OnAddSpell);
    }

    private void Start()
    {
        foreach (SpellInvoker spellInvoker in spellInvokers)
        {
            var panelCell = spellInvoker.gameObject.GetComponent<SpellPanelCell>();
            panelCells.Add(panelCell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("[1] Spell Panel Cell"))
        {
            spellInvokers[1].InvokeSpell();
        }
        if (Input.GetButtonDown("[2] Spell Panel Cell"))
        {
            spellInvokers[2].InvokeSpell();
        }
        if (Input.GetButtonDown("[3] Spell Panel Cell"))
        {
            spellInvokers[3].InvokeSpell();
        }
        if (Input.GetButtonDown("[4] Spell Panel Cell"))
        {
            spellInvokers[4].InvokeSpell();
        }
        if (Input.GetButtonDown("[5] Spell Panel Cell"))
        {
            spellInvokers[5].InvokeSpell();
        }
        if (Input.GetButtonDown("[6] Spell Panel Cell"))
        {
            spellInvokers[6].InvokeSpell();
        }
        if (Input.GetButtonDown("[7] Spell Panel Cell"))
        {
            spellInvokers[7].InvokeSpell();
        }
        if (Input.GetButtonDown("[8] Spell Panel Cell"))
        {
            spellInvokers[8].InvokeSpell();
        }
        if (Input.GetButtonDown("[9] Spell Panel Cell"))
        {
            spellInvokers[9].InvokeSpell();
        }
        if (Input.GetButtonDown("[0] Spell Panel Cell"))
        {
            spellInvokers[0].InvokeSpell();
        }

    }

    private void OnAddSpell(EventArg arg)
    {

        var id = arg.FirstIntArg;
        var icon = arg.Sprite;
        var spell = arg.Spell;

        foreach (SpellPanelCell cell in panelCells)
        {

            if (cell.Id == id)
            {
                cell.Image.sprite = icon;
                cell.SpellInvoker.Spell = spell;
            }
        }
    }
}
