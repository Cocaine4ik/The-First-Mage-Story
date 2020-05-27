using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Methods

    void Start()
    {
        PlayMusic();
    }

    private void Update() {
        
        if(!AudioManager.IsPlaying()) {

            StatusUtils.MusicOn = false;

            PlayMusic();
        }

    }

    private void PlayMusic() {

        if(!StatusUtils.MusicOn) {

            AudioManager.Play(AudioClipName.MainMenuTheme);
            StatusUtils.MusicOn = true;
        }
    }
    #endregion

    #region Button Events

    public void OnNewGameButton() {

        MenuManager.GoToMenu(MenuName.NewGame);

    }

    public void OnQuitButton() {

        Application.Quit();
    }

    #endregion
}
