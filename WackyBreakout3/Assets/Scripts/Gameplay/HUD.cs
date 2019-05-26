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
    public static float ballsLeft = 5;


   
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        ballsLeftText.text = "Balls Left: " + ballsLeft.ToString();
        EventManager.AddPointsAddedEventListener(AddPoints);
        EventManager.AddUpdateBallsLeftListener(UpdateBallsLeft);
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


    }




}
