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

    #endregion
}
