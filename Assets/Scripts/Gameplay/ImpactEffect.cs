using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour {

    #region AnimationEvent

    private void OnAnimationIsEnd() {
        Destroy(gameObject);
    }

    #endregion
}
