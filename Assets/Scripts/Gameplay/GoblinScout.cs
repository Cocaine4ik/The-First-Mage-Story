using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScout : Enemy{

    protected override void Start() {
        base.Start();
        isRight = false;
        Debug.Log(hp);
    }
}
