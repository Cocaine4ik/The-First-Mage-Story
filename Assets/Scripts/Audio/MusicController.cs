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
            AudioManager.MusicAudioSource.Stop();
            AudioManager.BackgroundAudioSource.Stop();

            SwitchMainTheme();
        }
    }

    private void SwitchMainTheme() {
        switch (currentSceneName) {
            case "MainMenu":
                AudioManager.MusicAudioSource.Play(MusicClipName.MainMenuTheme);
                break;
            case "ValleyOfTheWinds":
                AudioManager.MusicAudioSource.Play(MusicClipName.Spirit); 
                AudioManager.BackgroundAudioSource.Play(BackgroundClipName.RainAndThunder);
                break;
            case "MagicCliffs":
                AudioManager.MusicAudioSource.Play(MusicClipName.MagicCliffsTheme);
                AudioManager.BackgroundAudioSource.Play(BackgroundClipName.WindBackground);
                break;
        }
    }

}
