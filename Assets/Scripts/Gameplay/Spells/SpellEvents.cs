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
        Debug.Log(atackTrigger.gameObject.name);
    }
    #region Events

    private void CastProjectile(GameObject projectilePrefab, int damage, DamageType damageType, EffectName effect) {

        var projectileData = projectilePrefab.GetComponent<Projectile>();
        projectileData.Damage = damage;
        projectileData.DamageType = damageType;
        projectileData.Effect = effect;

        var projectile = Instantiate(projectilePrefab, new Vector2(atackTrigger.gameObject.transform.position.x,
        atackTrigger.gameObject.transform.position.y), atackTrigger.gameObject.transform.rotation);

        projectile.GetComponent<Projectile>().SetOwner(gameObject);
    }
    private void OnCastFireball(EventArg arg) {
        var spell = arg.Spell;
        CastProjectile(spell.ProjectilePrefab, spell.SpellDamage, spell.DamageType, spell.SpellEffect);        
        Debug.Log("Cast: " + spell.name);
    }
    private void OnCastFrostbolt(EventArg arg) {
        Debug.Log("Cast: " + arg.Spell.name.ToString());
    }

    
    #endregion
}
