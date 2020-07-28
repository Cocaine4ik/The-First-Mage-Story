using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public enum RequiredSkill {
    Knowledge,
    Wisdom,
    Spirit,
    Faith,
    Demons
}

public class SpellCell : Cell<SpellPanelCell> {

    [SerializeField] private Sprite learnedSpellIcon;
    [SerializeField] private Spell spell;

    [SerializeField] private RequiredSkill requiredSkill;
    [SerializeField] private int requiredSkillValue;

    private bool requirementDone = false;
    private bool isLearned = false;

    private Button button;

    protected override void Start() {

        base.Start();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => LearnSpell());

        CheckRequirement(requiredSkill);
    }

    private void LearnSpell() {
        if(!requirementDone) {
            CheckRequirement(requiredSkill);
        }
        if (!isLearned && Attributes.Instance.SpellPoints > 0 && requirementDone) {
            Attributes.Instance.DecreaseSpellPoints();
            isLearned = true;
            canDrag = true;
            icon.sprite = learnedSpellIcon;
            EventManager.TriggerEvent(EventName.RefreshSpellBook);
        }
    }

    public override void SetPanelCell()
    {
        if(panelCell != null)
        {
            var panelCellData = panelCell.GetComponent<SpellPanelCell>();
            EventManager.TriggerEvent(EventName.AddSpelltoPanelCell, new EventArg(panelCellData.Id, icon.sprite, spell));
        }
        
    }

    private void CheckRequirement(RequiredSkill skill) {
        switch(skill) {
            case RequiredSkill.Knowledge:
                if (Attributes.Instance.Knowledge >= requiredSkillValue) requirementDone = true;
                else requirementDone = false;
                break;
            case RequiredSkill.Wisdom:
                if (Attributes.Instance.Wisdom >= requiredSkillValue) requirementDone = true;
                else requirementDone = false;
                break;
            case RequiredSkill.Spirit:
                if (Attributes.Instance.Spirit >= requiredSkillValue) requirementDone = true;
                else requirementDone = false;
                break;
            case RequiredSkill.Faith:
                if (Attributes.Instance.Faith >= requiredSkillValue) requirementDone = true;
                else requirementDone = false;
                break;
            case RequiredSkill.Demons:
                if(requiredSkillValue > 0) {
                    if (Attributes.Instance.Demons >= requiredSkillValue) requirementDone = true;
                    else requirementDone = false;
                }
                else if (requiredSkillValue == 0) {
                    requirementDone = true;
                }
                else if (requiredSkillValue < 0) {
                    if (Attributes.Instance.Demons <= requiredSkillValue) requirementDone = true;
                    else requirementDone = false;
                }
                break;
        }
    }
}
