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

public class SpellCell : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    [SerializeField] private Sprite spellIcon;
    [SerializeField] private Sprite learnedSpellIcon;

    [SerializeField] private RequiredSkill requiredSkill;
    [SerializeField] private int requiredSkillValue;

    private bool requirementDone = false;
    private bool isLearned = false;
    private bool onPanel = false;
    private Spell spellData;
    private Button button;
    private Image cellIcon;

    private GameObject draggingCell;
    private SpellCell draggingCellData;

    private GameObject spellPanelCell;

    public bool OnPanel => onPanel;
    public GameObject SpellPanelCell {
        get { return spellPanelCell; }
        set { spellPanelCell = value; }
    }

    private void Start() {
        spellData = GetComponent<SpellInvoker>().SpellData;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => LearnSpell());
        cellIcon = GetComponent<Image>();

        CheckRequirement(requiredSkill);
    }

    private void LearnSpell() {
        if (!isLearned && Attributes.Instance.SpellPoints > 0 && requirementDone) {
            Attributes.Instance.DecreaseSpellPoints();
            isLearned = true;
            cellIcon.sprite = learnedSpellIcon;
            EventManager.TriggerEvent(EventName.RefreshSpellBook);
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (isLearned) {
            draggingCell.transform.position = Input.mousePosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (isLearned) {

        draggingCell = Instantiate(gameObject, gameObject.transform.parent.transform.parent);
        draggingCell.transform.position = Input.mousePosition;
        draggingCellData = draggingCell.GetComponent<SpellCell>();

        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (isLearned) {
            draggingCellData.SetSpellPanelCell();
            Destroy(draggingCell);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<SpellPanelCell>()) {
            onPanel = true;
            spellPanelCell = collision.gameObject;
            Debug.Log("onPanel: " + onPanel);
        }
    }

    public void SetSpellPanelCell() {
        var panellCellImage = spellPanelCell.GetComponent<Image>();
        panellCellImage.sprite = cellIcon.sprite;

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
                if (Attributes.Instance.Demons >= requiredSkillValue) requirementDone = true;
                else requirementDone = false;
                break;
        }
    }
}
