using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEvents : MonoBehaviour
{
    private Transform atackTrigger;

    private void OnEnable() {
        EventManager.StartListening(EventName.CastFireball, OnCastFireball);
        EventManager.StopListening(EventName.CastFrostbolt, OnCastFrostbolt);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.CastFireball, OnCastFireball);
        EventManager.StopListening(EventName.CastFrostbolt, OnCastFrostbolt);
    }

    private void Start() {

        atackTrigger = GetComponent<Player>().AtackTrigger;
    }
    #region Events

    private void CastProjectile(GameObject projectilePrefab) {

        GameObject projectile = Instantiate(projectilePrefab, new Vector2(atackTrigger.gameObject.transform.position.x,
        atackTrigger.gameObject.transform.position.y), atackTrigger.gameObject.transform.rotation);

        projectile.GetComponent<Projectile>().SetOwner(gameObject);
    }
    private void OnCastFireball(EventArg arg) {

        CastProjectile(arg.Spell.ProjectilePrefab);        
        Debug.Log("Cast: " + arg.Spell.name.ToString());
    }
    private void OnCastFrostbolt(EventArg arg) {
        Debug.Log("Cast: " + arg.Spell.name.ToString());
    }

    
    #endregion
}
