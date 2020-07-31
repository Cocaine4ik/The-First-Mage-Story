using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Supply Item")]
public class SupplyItem : Item, IResistance
{
    #region

    [Header("Supply Bonuses")]
    [SerializeField] private int healthRestoration;
    [SerializeField] private int manaRestoration;

    [SerializeField] private int healthBonus;
    [SerializeField] private int manaBonus;
    [SerializeField] private int damageBonus;

    [Header("Resistance Bonuses")]
    [SerializeField] private int physicalResistanceBonus;
    [SerializeField] private int veilResistannceBonus;
    [SerializeField] private int fireResistanceBonus;
    [SerializeField] private int iceResistanceBonus;
    [SerializeField] private int natureResistanceBonus;
    [SerializeField] private int divineResitanceBonus;

    [Header("Duration")]
    [SerializeField] private bool isDurable;
    [SerializeField] private float bonusDuration;

    #endregion

    #region Properties

    public int HealthBonus => healthBonus;
    public int ManaBonus => manaBonus;
    public int DamageBonus => damageBonus;
    public int PhysicalResistance => physicalResistanceBonus;
    public int VeilResistannce => veilResistannceBonus;
    public int FireResistance => fireResistanceBonus;
    public int IceResistance => iceResistanceBonus;
    public int NatureResistance => natureResistanceBonus;
    public int DivineResitance => divineResitanceBonus;
    public bool IsDurable => isDurable;
    public float BonusDuratation => bonusDuration;
    #endregion

    protected override void OnEnable()
    {
        base.OnEnable();
        itemColor = new Color32(0, 0, 0, 255);
        isSellable = true;
    }
}
