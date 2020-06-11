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
        draggingCellData = draggingCell.GetComponent<SpellCell>();
    }

    public void OnEndDrag(PointerEventData eventData) {
        draggingCellData.SetSpellPanelCell();
        Destroy(draggingCell);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<SpellPanelCell>()) {
            onPanel = true;
            spellPanelCell = collision.gameObject;
            Debug.Log("onPanel: " +  onPanel);      
            collision.

        }
    }

    public void SetSpellPanelCell() {
        var panellCellImage = spellPanelCell.GetComponent<Image>();
        panellCellImage.sprite = cellIcon.sprite;

    }
}
