using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disaster : MonoBehaviour
{
    private AtackWeapon weapon;

    private void Start() {
        weapon = GetComponent<AtackWeapon>();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        
        if(collision.gameObject.GetComponent<CharacterHealth>() != null) {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(weapon.Damage);
        }
    }
}
