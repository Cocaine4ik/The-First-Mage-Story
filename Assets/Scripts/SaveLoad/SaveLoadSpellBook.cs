using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSpellBook : SaveLoadData
{
    private SpellBook spellBook;

    private void Awake()
    {
        spellBook = GetComponent<SpellBook>();    
    }
    protected override void OnLoadData(EventArg arg)
    {

    }

    protected override void OnSaveData(EventArg arg)
    {
        foreach(SpellCell cell in spellBook.SpellCells)
        {
            if (cell.IsLearned) PlayerPrefs.SetString("SpellCell." + cell.Spell.SpellName.ToString(),
                 cell.Spell.SpellName.ToString());
        }
    }

}
