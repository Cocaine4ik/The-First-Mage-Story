using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCharacter : Character {

    [SerializeField] protected GameObject projectilePrefab;

        protected void OnRangeAtack() {

        GameObject projectile = Instantiate(projectilePrefab, new Vector3(atackWeapon.gameObject.transform.position.x,
            atackWeapon.gameObject.transform.position.y,
            atackWeapon.gameObject.transform.position.z), atackWeapon.gameObject.transform.rotation);

        projectile.GetComponent<Projectile>().SetOwner(gameObject);
    }
}
