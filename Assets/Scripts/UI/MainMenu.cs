using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Methods

    void Start()
    {
        AudioManager.Play(AudioClipName.MainMenuTheme);
    }

    public void OnNewGameButton() {

        MenuManager.GoToMenu(MenuName.NewGame);

    }

    public void OnQuitButton() {

        Application.Quit();
    }
    #endregion
}
