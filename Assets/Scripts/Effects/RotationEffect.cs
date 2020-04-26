using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotate object in any direction (use negative speed for change direction) with custom speed and duration
/// </summary>
public class RotationEffect : MonoBehaviour
{

    #region Fields

    [SerializeField] private float speed = 45;
    [SerializeField] private float duration = 3;
    private RectTransform rectTransform;
    private Timer rotationTimer;
    #endregion


    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rotationTimer = gameObject.AddComponent<Timer>();
        rotationTimer.Duration = duration;
        rotationTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
        if(rotationTimer != null) {
            
            if(!rotationTimer.IsRunnig) {
                speed *= -1;
                rotationTimer.Run();
            }
        }
    }

    #endregion
}
