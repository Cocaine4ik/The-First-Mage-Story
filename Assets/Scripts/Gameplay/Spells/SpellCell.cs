using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellCell : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    [SerializeField] private Sprite spellIcon;
    [SerializeField] private Sprite learnedSpellIcon;

    private bool isLearned = false;
    private bool onPanel = false;
    private Spell spellData;
    private Button button;
    private Image cellIcon;

    private GameObject draggingCell;
    private GameObject spellPanelCell;
    private SpellPanelCell oldSpellPanelCellData;
    private SpellPanelCell newSpellPanelCellData;

    public bool OnPanel => onPanel;

    private void Start() {
        spellData = GetComponent<SpellInvoker>().SpellData;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => LearnSpell());
        cellIcon = GetComponent<Image>();
    }

    private void LearnSpell() {
        if (!isLearned && Attributes.Instance.SpellPoints > 0) {
            Attributes.Instance.DecreaseSpellPoints();
            isLearned = true;
            cellIcon.sprite = learnedSpellIcon;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        draggingCell.transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        draggingCell = Instantiate(gameObject, gameObject.transform.parent.transform.parent);
        draggingCell.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (draggingCell.GetComponent<SpellCell>().OnPanel) {
            Debug.Log("Test");
            newSpellPanelCellData = spellPanelCell.AddComponent<SpellPanelCell>();
            newSpellPanelCellData = oldSpellPanelCellData;
        }
        Destroy(draggingCell);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<SpellPanelCell>()) {
            onPanel = true;
            Debug.Log("onPanel: " +  onPanel);
            spellPanelCell = collision.gameObject;
            var spellPanelCellIamge = spellPanelCell.GetComponent<Image>();
            oldSpellPanelCellData = spellPanelCell.GetComponent<SpellPanelCell>();
            Debug.Log(spellPanelCell.name);
        }
    }
}
