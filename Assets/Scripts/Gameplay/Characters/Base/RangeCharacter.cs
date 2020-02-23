using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCharacter : Character {

    [SerializeField] protected GameObject projectilePrefab;

        protected void OnRangeAtack() {

        GameObject projectile = Instantiate(projectilePrefab, new Vector3(atackPoint.position.x, atackPoint.position.y,
            atackPoint.position.z), atackPoint.rotation);

        projectile.GetComponent<Projectile>().SetOwner(gameObject);
    }
}
