using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SupplyPanelCell : ActionPanelCell<SupplyInvoker>, IStack
{
    private bool isStack;
    private int itemNumber;
    [SerializeField] private TextMeshProUGUI itemNumberText;

    public InventoryCell InventoryCell{ get; set; }
    public bool IsStack { get => isStack; set => isStack = value; }
    public int ItemNumber { get => itemNumber; set => itemNumber = value; }

}
