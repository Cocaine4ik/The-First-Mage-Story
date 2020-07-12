using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class GameLevelLoader : MonoBehaviour
{
    [SerializeField] private Scene loadingScreen;
    private GameObject loadingScreenPrefab;
    private GameLevelName gameLevelToLoad;

    public void LoadGameLevel(GameLevelName name)
    {
        gameLevelToLoad = name;
        SceneManager.LoadScene(loadingScreen.name);
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == gameLevelToLoad.ToString())
        {
            
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(gameLevelToLoad.ToString());
        }
    }
}
