using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    #region Animation Event

    public void OnFireLightEnd() {

        Destroy(gameObject);

    }

    #endregion
}
