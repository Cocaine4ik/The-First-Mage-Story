using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistances : MonoBehaviour, IResistance
{
    [SerializeField] private int physicalResistance;
    [SerializeField] private int veilResistannce;
    [SerializeField] private int fireResistance;
    [SerializeField] private int iceResistance;
    [SerializeField] private int natureResistance;
    [SerializeField] private int divineResitance;

    public int PhysicalResistance => physicalResistance;
    public int VeilResistannce => veilResistannce;
    public int FireResistance => fireResistance;
    public int IceResistance => iceResistance;
    public int NatureResistance => natureResistance;
    public int DivineResitance => divineResitance;

    public void IncreaseResistances(int physical = 0, int veil = 0, int fire = 0, int ice = 0, int nature = 0, int divine = 0)
    {
        physicalResistance += physical;
        veilResistannce += veil;
        fireResistance += fire;
        iceResistance += ice;
        natureResistance += nature;
        divineResitance += divine;
    }

    public void DecreaseResistances(int physical = 0, int veil = 0, int fire = 0, int ice = 0, int nature = 0, int divine = 0)
    {
        physicalResistance -= physical;
        veilResistannce -= veil;
        fireResistance -= fire;
        iceResistance -= ice;
        natureResistance -= nature;
        divineResitance -= divine;
    }

}
