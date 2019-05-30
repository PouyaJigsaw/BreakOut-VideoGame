using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{

    [SerializeField]
    Text scoreText;
    
    [SerializeField]
    Text ballsLeftText;
    
     static float score = 0;
     public  static float ballsLeft = 5;

    bool gameOver = false;

    LastBallDestroyedEvent lastBallDestroyed;
    public static float Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }


    }

   
   
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        ballsLeftText.text = "Balls Left: " + ballsLeft.ToString();
        EventManager.AddPointsAddedEventListener(AddPoints);
        EventManager.AddUpdateBallsLeftListener(UpdateBallsLeft);    
        
        lastBallDestroyed = new LastBallDestroyedEvent();
        EventManager.AddLastBallInvoker(this);
        EventManager.AddLastBallListener(ShowGameOverMessage);
    }

    public static void UpdateBallsLeft()
    {
        ballsLeft--;
        
    }

     void AddPoints(float value)
    {
        score += value;
        
    }

    // Update is called once per frame
    void Update()
    {
          scoreText.text = "Score: " + score.ToString();
          ballsLeftText.text = "Balls Left: " + ballsLeft.ToString();

        if(!gameOver && ballsLeft == 0)
        {
            lastBallDestroyed.Invoke();
            AudioManager.Play(AudioClipName.GameOver);
            gameOver = true;
        }

    }


    void ShowGameOverMessage()
    {
        Time.timeScale = 0;
        Object.Instantiate(Resources.Load("GameOverMenu"));
    }


    public void AddLastBallEventListener(UnityAction listener)
    {
        lastBallDestroyed.AddListener(listener);
    }



}
