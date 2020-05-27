using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controll music clips playing in case of active level
/// </summary>
public class MusicController : MonoBehaviour { 

    private string currentSceneName;

    private void Start() {

        currentSceneName = SceneManager.GetActiveScene().name;
        SwitchMainTheme();
    }
    private void Update() {
        
        if(currentSceneName != SceneManager.GetActiveScene().name) {

            currentSceneName = SceneManager.GetActiveScene().name;
            AudioManager.Stop();

            SwitchMainTheme();
        }
    }

    private void SwitchMainTheme() {
        switch (currentSceneName) {
            case "MainMenu":
                AudioManager.Play(AudioClipName.MainMenuTheme); break;
            case "ValleyOfTheWinds":
                AudioManager.Play(AudioClipName.RainAndThunder);
                AudioManager.Play(AudioClipName.Spirit); break;
            case "MagicCliffs": AudioManager.PlayInLoop(AudioClipName.WindBackground); break;
        }
    }

}
