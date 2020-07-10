using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResistance
{
    int PhysicalResistance { get; }
    int VeilResistannce { get; }
    int FireResistance { get; }
    int IceResistance { get; }
    int NatureResistance { get; }
    int DivineResitance { get; }
}
