using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {

    public static void GoToMenu(MenuName name) {
        switch(name) {

            case MenuName.Main: SceneManager.LoadScene("MainMenu"); break;
            case MenuName.Credits: SceneManager.LoadScene("Credits"); break;
            case MenuName.Profiles: SceneManager.LoadScene("Profiles"); break;
            case MenuName.Pause: Object.Instantiate(Resources.Load("Prefabs/UI/PauseMenu")); break;
        }
    }
}
