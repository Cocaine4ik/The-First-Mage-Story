
using UnityEngine;

/// <summary>
/// Self destroy event when animation is end
/// </summary>
public class SelfDestroy : MonoBehaviour
{

    public void OnSelfDestroy() {
        Destroy(gameObject);
    }
}
