using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb2d;
    float startAngle = 20f;

    BallSpawner ballSpawner;

    Timer ballDeathTimer;
    Timer speedUpTimer;
    Timer addForceTimer;
     
    bool deadInScreen = false;
    Vector2 colliderLowerLeft;
    Vector2 colliderUpperRight;
    bool  isSpeedUp = false;

    UpdateBallsLeftEvent updateBallsLeftEvent;
    // Start is called before the first frame update
    void Start()
    {

        updateBallsLeftEvent = new UpdateBallsLeftEvent();
        rb2d = GetComponent<Rigidbody2D>();

        ballSpawner = Camera.main.GetComponent<BallSpawner>();

        ballDeathTimer = gameObject.AddComponent<Timer>();
        ballDeathTimer.Duration = ConfigurationUtils.BallLifeTime;
        ballDeathTimer.Run();
       
        addForceTimer = gameObject.AddComponent<Timer>();
        addForceTimer.Duration = 1f;
        addForceTimer.Run();

        speedUpTimer = gameObject.AddComponent<Timer>();

        EventManager.AddSpeedUpListener(SpeedUpTheBall);

        EventManager.AddUpdateBallsLeftInvoker(this);

    }

    

    public void SetDirection(Vector2 direction)
    {

        rb2d.velocity =  direction * rb2d.velocity.magnitude;
    }
    // Update is called once per frame
    void Update()
    {
        if (addForceTimer.Finished)
        {
                AddForceToBall();
                RestoreForceTimer();
        }

        Debug.Log(rb2d.velocity);

        
        if(ballDeathTimer.Finished)
        {
            Destroy(gameObject);
            deadInScreen = true;
            if (HUD.ballsLeft > 0)
            {
                ballSpawner.SpawnABall();
                updateBallsLeftEvent.Invoke();
                addForceTimer.Run();
            }
          
        }

        if(speedUpTimer.Finished)
        {
            isSpeedUp = false;
            speedUpTimer.ResetTimer();
            rb2d.velocity /= ConfigurationUtils.SpeedUpFactor;
        }

       
    }

    void AddForceToBall()
    {
        float startAngleRadian = 270 * Mathf.Deg2Rad;
        Vector2 vectorForce = new Vector2(Mathf.Cos(startAngleRadian), Mathf.Sin(startAngleRadian));

       
       
       
        if (EffectUtils.IsSpeedUp)
        {
            rb2d.AddForce(vectorForce * ConfigurationUtils.BallImpulseForce * ConfigurationUtils.SpeedUpFactor);          
            //duration timer bayad baghimunde timer bashe
            speedUpTimer.Duration = EffectUtils.speedUpTimerRemain;
            speedUpTimer.Run();
        }
        else
        {
            rb2d.AddForce(vectorForce * ConfigurationUtils.BallImpulseForce);
        }
    }

    void RestoreForceTimer()
    {
        Destroy(addForceTimer);
        addForceTimer = gameObject.AddComponent<Timer>();
        addForceTimer.Duration = 1f;
    }


    void SpeedUpTheBall(float speedUpDuration, float speedUpFactor)
    {
        if (isSpeedUp == true)
        {
            speedUpTimer.AddSeconds(speedUpDuration);
        }
        else
        {
            isSpeedUp = true;

            rb2d.velocity *= speedUpFactor;
            speedUpTimer.Duration = speedUpDuration;
            speedUpTimer.Run();
        }

    }

    
   
    
    private void OnBecameInvisible()
    {
        if (!deadInScreen)
        {
            Destroy(gameObject);
            if (HUD.ballsLeft > 0)
            {
                ballSpawner.SpawnABall();
                updateBallsLeftEvent.Invoke();
                RestoreForceTimer();
            }

        }
    }


    public void AddUpdateBallsLeftListener(UnityAction listener)
    {
        updateBallsLeftEvent.AddListener(listener);
    }
}
