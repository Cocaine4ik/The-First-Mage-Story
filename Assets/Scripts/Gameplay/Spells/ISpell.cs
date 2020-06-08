using UnityEngine;
public interface ISpell
{
    SpellName SpellName { get; }
    GameObject SpellCastPrefab { get; }
    GameObject ProjectilePrefab { get; }
}
