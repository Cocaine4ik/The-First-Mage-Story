using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelCell : MonoBehaviour
{
    [SerializeField] private int id;
    private Image image;
    private SpellInvoker spellInvoker;
    private SupplyInvoker supplyInvoker;

    public int Id => id;
    public Image Image => image;
    public SpellInvoker SpellInvoker => spellInvoker;
    public SupplyInvoker SupplyInvoker => supplyInvoker; 

    private void Start() {
        image = GetComponent<Image>();
        spellInvoker = GetComponent<SpellInvoker>();
        supplyInvoker = GetComponent<SupplyInvoker>();
    }

}
