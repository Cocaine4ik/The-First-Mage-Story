using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInvoker : MonoBehaviour
{
    [SerializeField] private Spell spell;

    public Spell Spell {
        get { return spell; }
        set { spell = value; }
    }

    public void InvokeSpell() {
        if(spell != null) {
            EventManager.TriggerEvent(spell.InvokeEvent, new EventArg(spell));
        }
        else {
            // AudioManager.SFXAudioSource.Play(SFXClipName.MagicArrow);
        }
    }
}
