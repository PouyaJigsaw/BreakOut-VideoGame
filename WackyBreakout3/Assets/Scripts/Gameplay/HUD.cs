using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    }

    public static void UpdateBallsLeft()
    {
        ballsLeft--;
    }

    public static void AddPoints(float value)
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
