using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCell : Cell<SupplyPanelCell>
{
    [SerializeField] private Image iconField;
    private ItemName itemName;
    private ItemType itemType;
    private Image borderField;
    private Color itemColor;
    private int itemNumber = 1;

    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private int id;
    [SerializeField] private bool isEmpty;
    [SerializeField] private bool isStack;

    public ItemName ItemName => itemName;
    public bool IsEmpty => isEmpty;
    public bool IsStack => isStack;

    private void Awake() {

        isEmpty = true;
        isStack = false;
        borderField = GetComponent<Image>();
       
    }

    public void SetId(int id) {

        this.id = id;
    }

    public void AddItemToCell(IITem item) {

        itemName = item.ItemName;
        itemType = item.ItemType;
        iconField.sprite = item.ItemIcon;
        borderField.sprite = item.ItemBorder;
        iconField.sprite = item.ItemIcon;
        itemColor = item.ItemColor;
        isEmpty = false;

        if (itemType == ItemType.SupplyItem || itemType == ItemType.RelicItem)
        {
            canDrag = true;
        }
    }

    public void OnInventoryCellSelected() {

        if (isEmpty == false) {
            EventManager.TriggerEvent(EventName.ShowInventoryItemData, new EventArg(itemName, itemType));
            EventManager.TriggerEvent(EventName.ChangeItemTypeColor, new EventArg(itemColor));
        }

    }
    public void AddItemToStack() {
        if(isStack == false) {
            itemNumberText.gameObject.SetActive(true);
            isStack = true;
        }
        itemNumber += 1;
        itemNumberText.text = itemNumber.ToString();
    }

    public override void SetPanelCell()
    {
        throw new System.NotImplementedException();
    }
}
