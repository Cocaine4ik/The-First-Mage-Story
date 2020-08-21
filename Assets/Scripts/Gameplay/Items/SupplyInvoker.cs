using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyInvoker : MonoBehaviour
{
    [SerializeField] private SupplyItem supply;
    private InventoryCell inventoryCell;

    public SupplyItem Supply { get => supply; set => supply = value; }

    private void Start()
    {
        inventoryCell = GetComponent<InventoryCell>();
    }
    public void InvokeSupply()
    {
        if (supply != null && supply.ItemNumber > 0)
        {
            // For instant supply effect
            if(!supply.IsDurable)
            {
                // Health and Mana Restoration
                Attributes.Instance.PlayerHealth.RestoreHealth(supply.HealthRestoration);
                Attributes.Instance.PlayerMana.RestoreMana(supply.ManaRestoration);
            }
            // for durable supply effect
            if(supply.IsDurable)
            {
                // Add bonus Health and Mana, Restore Health and Mana by bonus value
                Attributes.Instance.PlayerHealth.SetMaxHealth(Attributes.Instance.PlayerHealth.MaxValue + supply.HealthBonus);
                Attributes.Instance.PlayerHealth.RestoreHealth(supply.HealthBonus);
                Attributes.Instance.PlayerMana.SetMaxMana(Attributes.Instance.PlayerMana.MaxValue + supply.ManaBonus);
                Attributes.Instance.PlayerMana.RestoreMana(supply.ManaBonus);

                // Add bonus Resistances
                Attributes.Instance.Resistances.IncreaseResistances(supply.PhysicalResistance,
                    supply.VeilResistannce, supply.FireResistance, supply.IceResistance, supply.NatureResistance, supply.DivineResitance);

                StartCoroutine(StartDurableSupply(supply.BonusDuratation));
            }
            // remove item from the inventory
            
            if(supply.ItemNumber > 1)
            {
                InventorySystem.Instance.RemoveItem(supply.ItemName);
            }
            else
            {
                inventoryCell.ClearCell();
                inventoryCell.Icon.gameObject.SetActive(false);
                InventorySystem.Instance.RemoveItem(supply.ItemName);
                supply = null;
            }
        }
        else
        {
            // AudioManager.SFXAudioSource.Play(SFXClipName.MagicArrow);
        }
    }

    private IEnumerator StartDurableSupply(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
