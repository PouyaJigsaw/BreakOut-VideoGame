using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {

        switch(name)
            {
                case MenuName.Menu:
                    SceneManager.LoadScene("Menu");
                    break;
                case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;

            };

        
        
    }

}
