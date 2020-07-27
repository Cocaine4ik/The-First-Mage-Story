using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppplyPanel : MonoBehaviour
{
    [SerializeField] private List<SupplyInvoker> supplyInvokers;
    private List<SupplyPanelCell> panelCells = new List<SupplyPanelCell>();

    private void OnEnable()
    {
        //EventManager.StartListening(EventName.AddSpelltoPanelCell, OnAddSpell);
    }
    private void OnDisable()
    {
      //  EventManager.StopListening(EventName.AddSpelltoPanelCell, OnAddSpell);
    }

    private void Start()
    {
        foreach (SupplyInvoker spellInvoker in supplyInvokers)
        {
            var panelCell = spellInvoker.gameObject.GetComponent<SupplyPanelCell>();
            panelCells.Add(panelCell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("[1] Supply Panel Cell"))
        {
            supplyInvokers[0].InvokeSpell();
        }
        if (Input.GetButtonDown("[2] Supply Panel Cell"))
        {
            supplyInvokers[1].InvokeSpell();
        }
        if (Input.GetButtonDown("[3] Supply Panel Cell"))
        {
            supplyInvokers[2].InvokeSpell();
        }
        if (Input.GetButtonDown("[4] Supply Panel Cell"))
        {
            supplyInvokers[3].InvokeSpell();
        }

    }
    /*
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
    }*/
}
