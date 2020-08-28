using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Deployment.Internal;

public class InventoryCell : Cell<SupplyPanelCell>, IStack
{
    [SerializeField] private ItemName itemName = ItemName.Undefined;
    [SerializeField] private ItemType itemType = ItemType.Undefined;
    private Image borderField;
    private Color itemColor;
    private int itemNumber = 1;

    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private int id;
    [SerializeField] private bool isEmpty;
    [SerializeField] private bool isStack;

    public int ID => id;
    public ItemName ItemName => itemName;
    public bool IsEmpty => isEmpty;
    public bool IsStack { get => isStack; set => isStack = value; }
    public int ItemNumber { get => itemNumber; set => itemNumber = value; }

    private Sprite defaultBorder;

    private void OnDestroy()
    {
        EventManager.StopListening(EventName.ChangeItemNumber, OnChangeItemNumber);
    }
    protected override void Awake()
    {
        isEmpty = true;
        isStack = false;
        borderField = GetComponent<Image>();
        defaultBorder = borderField.sprite;
        EventManager.StartListening(EventName.ChangeItemNumber, OnChangeItemNumber);
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
        if (itemType == ItemType.Supply || itemType == ItemType.Relic)
        {
            canDrag = true;
        }
    }

    public void ClearCell()
    {
        itemName = ItemName.Undefined;
        itemType = ItemType.Undefined;
        icon.sprite = defaultIcon;
        borderField.sprite = defaultBorder;
        isEmpty = true;
        onPanel = false;
        isStack = false;

        itemNumberText.gameObject.SetActive(false);
    }
    public void OnInventoryCellSelected() {

        if (isEmpty == false) {
            EventManager.TriggerEvent(EventName.ShowInventoryItemData, new EventArg(itemName, itemType));
            EventManager.TriggerEvent(EventName.ChangeItemTypeColor, new EventArg(itemColor));
        }

    }
    public void SetItemStack(int num) {
        if(isStack == false) {
            itemNumberText.gameObject.SetActive(true);
            isStack = true;
        }
        itemNumber = num;
        itemNumberText.text = itemNumber.ToString();
    }

    public override void SetPanelCell()
    {
        if (panelCell != null)
        {
            var panelCellData = panelCell.GetComponent<SupplyPanelCell>();
            Debug.Log(itemName.ToString());
            var supply = InventorySystem.Instance.SupplyItems[itemName];
            Debug.Log(supply.ItemName);
            EventManager.TriggerEvent(EventName.AddSupplyToPanelCell, new EventArg(panelCellData.Id, supply));
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
    protected override void SetDragginCellData()
    {
        base.SetDragginCellData();
        var invenoryCellData = draggingCell.GetComponent<InventoryCell>();
        invenoryCellData.IsStack = isStack;
        invenoryCellData.ItemNumber = itemNumber;
    }

    private void OnChangeItemNumber(EventArg arg)
    {      
        var name = arg.ItemName;
        var number = arg.FirstIntArg;
        if(name == itemName)
        {
            SetItemStack(number);
        }
    }
}
