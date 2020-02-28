using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    /// <summary>
    /// Initialize the game
    /// </summary>
    private void Awake()
    {
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
        
    }

    /// <summary>
    /// Disable all monobehaviour scripts before out or stop applcation to predict null reference error
    /// </summary>
    private void OnApplicationQuit() {
        MonoBehaviour[] scripts = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;
    }
}
