using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SupplyPanelCell : ActionPanelCell<SupplyInvoker>, IStack
{
    private bool isStack = false;
    private int itemNumber = 1;
    [SerializeField] private TextMeshProUGUI itemNumberText;

    public InventoryCell InventoryCell{ get; set; }
    public bool IsStack { get => isStack; set => isStack = value; }
    public int ItemNumber { get => itemNumber; set => itemNumber = value; }

    public void SetStack()
    {
        if(IsStack)
        {
            Debug.Log("SetStack");
            itemNumberText.gameObject.SetActive(true);
            itemNumberText.text = itemNumber.ToString();
        }
    }

}
