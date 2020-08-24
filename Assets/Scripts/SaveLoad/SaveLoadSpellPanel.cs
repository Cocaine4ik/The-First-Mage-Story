using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

public class SaveLoadSpellPanel : SaveLoadData
{
    private SpellPanel spellPanel;

    private void Start()
    {
        spellPanel = GetComponent<SpellPanel>();
    }
    protected override void OnLoadData(EventArg arg)
    {
        foreach (SpellPanelCell cell in spellPanel.panelCells)
        {
            if(PlayerPrefs.HasKey("SpellPanelCell." + cell.Id.ToString()))
            {
                if(PlayerPrefs.GetString("SpellPanelCell." + cell.Id.ToString()) != "Empty")
                {
                    var spellName = PlayerPrefs.GetString("SpellPanelCell." + cell.Id.ToString());
                    var spell = Resources.Load<Spell>($"Data/Spells/{spellName}");
                    EventManager.TriggerEvent(EventName.AddSpelltoPanelCell, new EventArg(cell.Id, spell));
                }
            }
        }
    }

    protected override void OnSaveData(EventArg arg)
    {
        foreach(SpellPanelCell cell in spellPanel.panelCells)
        {
            var spell = cell.GetComponent<SpellInvoker>().Spell;
            var id = cell.Id;

            if(spell != null)
            {
                PlayerPrefs.SetString("SpellPanelCell." + id.ToString(), spell.SpellName.ToString());
            }
            else PlayerPrefs.SetString("SpellPanelCell." + id.ToString(), "Empty");
        }
    }
}
