using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenuEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void HandleHelpButtonOnClickEvent()
    {
        SceneManager.LoadScene("Help");
    }

    public void HandleBackToMenuOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Menu);
    }
}
