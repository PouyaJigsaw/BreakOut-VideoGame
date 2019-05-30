using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene("Gameplay");
    }

    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Application.Quit();
    }

    
}
