using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disaster : MonoBehaviour
{
    private DamageData damageData;

    private void Start() {
        damageData = GetComponent<DamageData>();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        
        if(collision.gameObject.GetComponent<CharacterHealth>() != null) {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damageData.Damage);
        }
    }
}
