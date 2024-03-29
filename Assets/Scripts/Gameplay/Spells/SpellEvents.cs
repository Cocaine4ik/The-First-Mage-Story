﻿using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class SpellEvents : MonoBehaviour
{
    private Transform atackTrigger;
    private Spell invokedSpell;
    private Animator animator;
    private MagicCharacter magicCharacter;

    private void OnEnable() {
        EventManager.StartListening(EventName.InvokeSpell, OnInvokeSpell);
      
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.InvokeSpell, OnInvokeSpell);
    }

    private void Start() {
        magicCharacter = GetComponentInChildren<MagicCharacter>();
        atackTrigger = GetComponent<Player>().AtackTrigger;
        animator = GetComponent<Animator>();
    }
    #region Events

    private void OnInvokeSpell(EventArg arg) {
        invokedSpell = arg.Spell;
        animator.SetTrigger(invokedSpell.name.ToString());
        magicCharacter.IsCast = true;
        Debug.Log(magicCharacter.IsCast);
    }

    private void CastProjectile(GameObject projectilePrefab, int damage, DamageType damageType, EffectName effect) {

        var projectileData = projectilePrefab.GetComponent<Projectile>();
        projectileData.Damage = damage;
        projectileData.DamageType = damageType;
        projectileData.Effect = effect;

        var projectile = Instantiate(projectilePrefab, new Vector2(atackTrigger.gameObject.transform.position.x,
        atackTrigger.gameObject.transform.position.y), atackTrigger.gameObject.transform.rotation);

        projectile.GetComponent<Projectile>().SetOwner(gameObject);
        Debug.Log("Cast: " + invokedSpell.name);
    }

    private void OnCastSpell() {
        CastProjectile(invokedSpell.ProjectilePrefab, invokedSpell.SpellDamage, invokedSpell.DamageType, invokedSpell.SpellEffect);
        magicCharacter.IsCast = false;
        Debug.Log(magicCharacter.IsCast);
    }
  
    #endregion
}
