using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenuEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void HandleHelpButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene("Help");
    }

    public void HandleBackToMenuOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu(MenuName.Menu);
    }
}
