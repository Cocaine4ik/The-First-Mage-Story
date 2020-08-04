﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyPanel : MonoBehaviour
{
    [SerializeField] private List<SupplyInvoker> supplyInvokers;
    private List<SupplyPanelCell> panelCells = new List<SupplyPanelCell>();

    private void OnEnable()
    {
        EventManager.StartListening(EventName.AddSupplyToPanelCell, OnAddSupply);
    }
    private void OnDisable()
    {
       EventManager.StopListening(EventName.AddSupplyToPanelCell, OnAddSupply);
    }

    private void Start()
    {
        foreach (SupplyInvoker spellInvoker in supplyInvokers)
        {
            var panelCell = spellInvoker.gameObject.GetComponent<SupplyPanelCell>();
            panelCells.Add(panelCell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("[1] Supply Panel Cell"))
        {
            Debug.Log("Invoke Supply");
            supplyInvokers[0].InvokeSupply();
        }
        if (Input.GetButtonDown("[2] Supply Panel Cell"))
        {
            Debug.Log("Invoke Supply");
            supplyInvokers[1].InvokeSupply();
        }
        if (Input.GetButtonDown("[3] Supply Panel Cell"))
        {
            Debug.Log("Invoke Supply");
            supplyInvokers[2].InvokeSupply();
        }
        if (Input.GetButtonDown("[4] Supply Panel Cell"))
        {
            Debug.Log("Invoke Supply");
            supplyInvokers[3].InvokeSupply();
        }

    }
    
    private void OnAddSupply(EventArg arg)
    {
        var id = arg.FirstIntArg;
        var inventoryCell = arg.Cell;
        Debug.Log(inventoryCell.IsStack);
        var supply = arg.Supply;

        foreach (SupplyPanelCell cell in panelCells)
        {   
            if(cell.Invoker.Supply != null)
            {
                if (cell.Invoker.Supply.ItemName == supply.ItemName)
                {
                    cell.Invoker.Supply = null;
                    cell.Image.sprite = null;
                    cell.Image.gameObject.SetActive(false);
                }
            }

            if (cell.Id == id)
            {
                cell.Image.gameObject.SetActive(true);
                cell.Image.sprite = inventoryCell.Icon.sprite;
                cell.Invoker.Supply = supply;
                if(inventoryCell.IsStack)
                {
                    cell.IsStack = inventoryCell.IsStack;
                    cell.ItemNumber = inventoryCell.ItemNumber;
                    cell.SetStack();
                }
                
            }
        }
    }
}
