using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image iconField;
    [SerializeField] private int id;
    [SerializeField] private bool isEmpty;


    public bool IsEmpty => isEmpty;

    private void Awake() {

        isEmpty = true;
    }

    public void SetId(int id) {

        this.id = id;
    }

    public void Render(IITem item) {

        iconField.sprite = item.ItemIcon;
    }
   
}
