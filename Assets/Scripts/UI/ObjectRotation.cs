using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{

    #region Fields

    [SerializeField] private float speed = 45;
    RectTransform rectTransform;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }

    #endregion
}
