using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellPanelCell : ActionPanelCell<SpellInvoker>
{
    protected override void Start()
    {
        base.Start();
        image = GetComponent<Image>();
    }
}
