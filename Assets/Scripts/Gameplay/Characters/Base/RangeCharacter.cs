using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCharacter : Character {

    [SerializeField] protected GameObject projectilePrefab;

    public GameObject ProjectilePrefab => projectilePrefab;

        protected void OnRangeAtack() {

        GameObject projectile = Instantiate(projectilePrefab, new Vector3(atackTrigger.gameObject.transform.position.x,
            atackTrigger.gameObject.transform.position.y,
            atackTrigger.gameObject.transform.position.z), atackTrigger.gameObject.transform.rotation);

        projectile.GetComponent<Projectile>().SetOwner(gameObject);
    }
}
