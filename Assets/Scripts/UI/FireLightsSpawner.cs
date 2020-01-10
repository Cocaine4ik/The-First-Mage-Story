using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightsSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField] private float timerDuration = 2f;

    [SerializeField] private GameObject[] fireLightsCastleCenter;
    [SerializeField] private GameObject[] fireLightsCastleTowers;
    [SerializeField] private GameObject[] fireLightsBlackHouseOne;
    [SerializeField] private GameObject[] fireLightsBlackHouseTwo;
    [SerializeField] private GameObject[] fireLightsChurch;
    [SerializeField] private GameObject[] fireLightsSmallHouse;

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
            case 1: ShowFireLight(fireLightsChurch); break;
            case 2: ShowFireLight(fireLightsBlackHouseOne); break;
            case 3: ShowFireLight(fireLightsSmallHouse); break;
            case 4: ShowFireLight(fireLightsCastleCenter); break;
            case 5: ShowFireLight(fireLightsBlackHouseTwo); break;
            case 6: ShowFireLight(fireLightsCastleTowers); break;
        }
    }

    private void ShowFireLight(GameObject[] fireLights) {

        if(fireLightSpawnTimer.Finished) {
              
            GameObject currentFireLight = fireLights[Random.Range(0, fireLights.Length)];
            currentFireLight.SetActive(true);
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
