using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyInvoker : MonoBehaviour
{
    [SerializeField] private SupplyItem supply;

    public SupplyItem Supply { get => supply; set => supply = value; }

    public void InvokeSupply()
    {
        if (supply != null)
        {
            EventManager.TriggerEvent(EventName.InvokeSupply, new EventArg(supply));
            if(!supply.IsDurable)
            {

            }
        }
        else
        {
            // AudioManager.SFXAudioSource.Play(SFXClipName.MagicArrow);
        }
    }
}
