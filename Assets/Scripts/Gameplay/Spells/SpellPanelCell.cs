using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellPanelCell : MonoBehaviour
{
    [SerializeField] private int id;
    private Image image;
    private SpellInvoker spellInvoker;

    public int Id => id;
    public Image Image => image;
    public SpellInvoker SpellInvoker => spellInvoker;

    private void Start() {
        image = GetComponent<Image>();
        spellInvoker = GetComponent<SpellInvoker>();
    }

}
