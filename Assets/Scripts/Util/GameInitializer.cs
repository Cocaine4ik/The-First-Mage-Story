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
}
