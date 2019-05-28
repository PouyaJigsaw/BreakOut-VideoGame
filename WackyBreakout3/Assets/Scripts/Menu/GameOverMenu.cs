using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    Text highScoreText;

    private void Start()
    {
        highScoreText.text = "Score: " + HUD.Score;
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Time.timeScale = 1;      
        MenuManager.GoToMenu(MenuName.Menu);
    }
}
