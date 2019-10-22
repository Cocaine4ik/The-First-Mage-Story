using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC {

    protected override void AddEnemyTags() {

        enemyTags.Add("NPC");
        enemyTags.Add("Player");
    }
}
