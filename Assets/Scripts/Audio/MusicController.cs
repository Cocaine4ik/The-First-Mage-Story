﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour { 

    private string currentSceneName;

    private void Start() {

        currentSceneName = SceneManager.GetActiveScene().name;

    }
    private void Update() {
        
        if(currentSceneName != SceneManager.GetActiveScene().name) {

            currentSceneName = SceneManager.GetActiveScene().name;
            AudioManager.Stop();
            
            switch(currentSceneName) {
            case "MainMenu": AudioManager.Play(AudioClipName.MainMenuTheme); break;
            case "MagicCliffs": break;
            }
        }

    }
}