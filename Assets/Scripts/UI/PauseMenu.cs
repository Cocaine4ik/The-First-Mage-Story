using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : UIElementBase
{
    public void GoToMainMenu()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
