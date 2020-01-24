using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image iconField;

    public void Render(IITem item) {

        iconField.sprite = item.ItemIcon;
    }
   
}
