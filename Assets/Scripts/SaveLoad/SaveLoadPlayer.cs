using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPlayer : SaveLoadData
{
    protected override void OnSaveData(EventArg arg) {
       
        // Player position
        PlayerPrefs.SetFloat("PositionX", Attributes.Instance.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", Attributes.Instance.transform.position.y);

        // Player experience data
        PlayerPrefs.SetInt("CurrentExp", Attributes.Instance.CurrentExp);
        PlayerPrefs.SetInt("CurrentLevel", Attributes.Instance.CurrentLevel);

        // Player stats data
        PlayerPrefs.SetInt("Knowledge", Attributes.Instance.Knowledge);
        PlayerPrefs.SetInt("Wisdom", Attributes.Instance.Wisdom);
        PlayerPrefs.SetInt("Spirit", Attributes.Instance.Spirit);
        PlayerPrefs.SetInt("Faith", Attributes.Instance.Faith);
        PlayerPrefs.SetInt("Demons", Attributes.Instance.Demons);
        PlayerPrefs.SetInt("Alchemy", Attributes.Instance.Alchemy);

        // Player skill and spell points data
        PlayerPrefs.SetInt("SkillPoints", Attributes.Instance.SkillPoints);
        PlayerPrefs.SetInt("SpellPoints", Attributes.Instance.SpellPoints);

    }

    protected override void OnLoadData(EventArg arg) {

        var posX = PlayerPrefs.GetFloat("PositionX");
        var posY = PlayerPrefs.GetFloat("PositionY");
        Attributes.Instance.transform.position = new Vector2(posX, posY);
        Debug.Log("Load Player positon.");

        var level = PlayerPrefs.GetInt("CurrentLevel");
        Attributes.Instance.SetLevel(level);
        Attributes.Instance.SetExpToLevelUp(level);
        var exp = PlayerPrefs.GetInt("CurrentExp");
        Attributes.Instance.AddExp(exp);

        var knowledge = PlayerPrefs.GetInt("Knowledge");
        Attributes.Instance.Knowledge = knowledge;
        Attributes.Instance.ChangeKnowledge(true);

        var wisdom = PlayerPrefs.GetInt("Wisdom");
        Attributes.Instance.Wisdom = wisdom;
        Attributes.Instance.ChangeWisdom(true);

        var spirit = PlayerPrefs.GetInt("Spirit");
        Attributes.Instance.Spirit = spirit;
        Attributes.Instance.ChangeSpirit(true);

        var faith = PlayerPrefs.GetInt("Faith");
        Attributes.Instance.Faith = faith;
        Attributes.Instance.ChangeFaith(true);

        var demons = PlayerPrefs.GetInt("Demons");
        Attributes.Instance.Demons = demons;

        var alchemy = PlayerPrefs.GetInt("Alchemy");
        Attributes.Instance.Alchemy = alchemy;
        
        var skillPoints = PlayerPrefs.GetInt("SkillPoints");
        var spellPoints = PlayerPrefs.GetInt("SpellPoints");
        Attributes.Instance.AddSkillPoints(skillPoints);
        Attributes.Instance.AddSpellPoints(spellPoints);

        // Restore current health to max health
        Attributes.Instance.PlayerHealth.RestoreHealth(Attributes.Instance.PlayerHealth.MaxValue);

        // Restore current mana to max mana
        Attributes.Instance.PlayerMana.RestoreMana(Attributes.Instance.PlayerMana.MaxValue);
    }
}
