using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSupplyPanel : SaveLoadData
{
    private SupplyPanel panel;

    private void Start()
    {
        panel = GetComponent<SupplyPanel>();
    }
    protected override void OnLoadData(EventArg arg)
    {
        foreach(SupplyPanelCell panelCell in panel.panelCells)
        {
            if (PlayerPrefs.HasKey("SupplyPanelCell." + panelCell.Id)) {

                var itemName = PlayerPrefs.GetString("SupplyPanelCell." + panelCell.Id);
                if(itemName != "Undefined")
                {
                    var name = (ItemName)Enum.Parse(typeof(ItemName), itemName);
                    EventManager.TriggerEvent(EventName.AddSupplyToPanelCell, new EventArg(panelCell.Id,
                        InventorySystem.Instance.SupplyItems[name]));
                }
            }
        }
    }

    protected override void OnSaveData(EventArg arg)
    {
        foreach(SupplyPanelCell panelCell in panel.panelCells)
        {
            var cell = panelCell.GetComponent<InventoryCell>();

                PlayerPrefs.SetString("SupplyPanelCell." + panelCell.Id.ToString(), cell.ItemName.ToString());
        }
    }

}
