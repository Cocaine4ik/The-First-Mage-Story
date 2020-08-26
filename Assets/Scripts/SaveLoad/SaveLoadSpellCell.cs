using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSpellCell : SaveLoadData
{
    private SpellCell spellCell;

    private void Start()
    {
        spellCell = GetComponent<SpellCell>();

    }
    protected override void OnEnable()
    {/*
        base.OnEnable();
        OnLoadData(new EventArg());*/
    }
    protected override void OnLoadData(EventArg arg)
    {/*
        if (spellCell != null && spellCell.Spell != null)
        {
            if (PlayerPrefs.HasKey("SpellCell." + spellCell.Spell.SpellName.ToString()))
                spellCell.LearnSpell(true);
        }*/
    }

    protected override void OnSaveData(EventArg arg)
    {
        
    }
}
