using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCell : Cell<SupplyPanelCell>, IStack
{
    [SerializeField] private ItemName itemName;
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
    public bool IsStack { get => isStack; set => isStack = value; }
    public int ItemNumber { get => itemNumber; set => itemNumber = value; }

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
        icon.sprite = item.ItemIcon;
        borderField.sprite = item.ItemBorder;
        itemColor = item.ItemColor;
        isEmpty = false;
        Debug.Log(itemName);
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
        if (panelCell != null)
        {
            var panelCellData = panelCell.GetComponent<SupplyPanelCell>();
            Debug.Log(itemName.ToString());
            var supply = Resources.Load<SupplyItem>("Data/Items/Supply/" + itemName.ToString());
            Debug.Log(supply.ItemName);
            EventManager.TriggerEvent(EventName.AddSupplyToPanelCell, new EventArg(panelCellData.Id, GetComponent<InventoryCell>(), supply));
            Debug.Log("Add Supply" + icon.sprite);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SupplyPanelCell>() != null)
        {
            onPanel = true;
            panelCell = collision.gameObject;
            Debug.Log("onPanel: " + onPanel);
        }
    }
}
