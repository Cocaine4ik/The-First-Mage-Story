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
        foreach (SpellCell cell in spellBook.SpellCells)
        {
            if(cell.Spell != null)
            {
                Debug.Log("LoadSpell: " + cell.Spell.SpellName.ToString());
                if (PlayerPrefs.HasKey("SpellCell." + cell.Spell.SpellName.ToString()))
                {
                    Debug.Log("LoadSpell 2");
                    cell.LearnSpell(true);
                }
            }
        }
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
