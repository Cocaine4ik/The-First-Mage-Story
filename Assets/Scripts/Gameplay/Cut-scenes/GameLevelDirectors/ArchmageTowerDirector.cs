using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ArchmageTowerDirector : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (virtualCamera.m_Lens.OrthographicSize < 8)
        {
            virtualCamera.m_Lens.OrthographicSize += 0.01f;
        }
    }
}
