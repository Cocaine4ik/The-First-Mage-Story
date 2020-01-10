using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightsSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField] private float timerDuration = 2f;
    [SerializeField] private GameObject fireLightPrefab;
    [SerializeField] private GameObject canvas;

    [SerializeField] private Vector2[] castleCenterPos;
    [SerializeField] private Vector2[] castleTowerPos;
    [SerializeField] private Vector2[] blackHouseOnePos;
    [SerializeField] private Vector2[] blackHouseTwoPos;
    [SerializeField] private Vector2[] churchPos;
    [SerializeField] private Vector2[] smallHousePos;

    Timer fireLightSpawnTimer;

    private int queue = 1;

    #endregion

    #region Methods

    private void Start() {

        fireLightSpawnTimer = GetComponent<Timer>();
        fireLightSpawnTimer.SetTimerName(TimerName.fireLightSpawnTimer);
        fireLightSpawnTimer.Duration = timerDuration;
        fireLightSpawnTimer.Run();

    }

    void Update()
    {

        switch(queue) {
            case 1: SpawnFireLight(churchPos); break;
                case 2: SpawnFireLight(blackHouseOnePos); break;
                case 3: SpawnFireLight(smallHousePos); break;
                case 4: SpawnFireLight(castleCenterPos); break;
                case 5: SpawnFireLight(blackHouseTwoPos); break;
                case 6: SpawnFireLight(castleTowerPos); break;
    }
    
    }

    private void SpawnFireLight(Vector2[] fireLightsPos) {

        if(fireLightSpawnTimer.Finished) {
              
            Vector2 currentPos = fireLightsPos[Random.Range(0, fireLightsPos.Length)];

            GameObject fireLight= Instantiate(fireLightPrefab, canvas.transform);
            fireLight.transform.localPosition = currentPos;

            fireLightSpawnTimer.Run();

            if(queue == 6) {

                queue = 1;

            }
            else {

                queue++;
                
            }


        }
    }

    #endregion
}
