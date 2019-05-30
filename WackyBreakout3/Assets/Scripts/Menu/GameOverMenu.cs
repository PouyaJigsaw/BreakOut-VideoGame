using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    Text highScoreText;

    [SerializeField]
    Text gameOverText;
    private void Start()
    {
     
        Time.timeScale = 0;

        if (PlayerPrefs.HasKey("High Score"))
        {
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");
        }
        else
        {
            highScoreText.text = "No games played yet";
        }
       
        EventManager.AddLastBlockDestroyedListener(YouWon);


    }

    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Menu);
    }

    public void YouWon()
    {
        gameOverText.text = "You Won!";
    }

}
