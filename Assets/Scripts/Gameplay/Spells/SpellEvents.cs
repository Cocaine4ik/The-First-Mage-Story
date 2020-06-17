using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEvents : MonoBehaviour
{

    private void OnEnable() {
        EventManager.StartListening(EventName.CastFireball, OnCastFireball);
        EventManager.StopListening(EventName.CastFrostbolt, OnCastFrostbolt);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.CastFireball, OnCastFireball);
        EventManager.StopListening(EventName.CastFrostbolt, OnCastFrostbolt);
    }

    #region Events

    private void OnCastFireball(EventArg arg) {
        Debug.Log("Cast: " + arg.Spell.name.ToString());
    }
    private void OnCastFrostbolt(EventArg arg) {
        Debug.Log("Cast: " + arg.Spell.name.ToString());
    }
    #endregion
}
