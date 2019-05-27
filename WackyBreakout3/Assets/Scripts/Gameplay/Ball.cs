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

        addForceTimer.AddTimerFinishedEventListener(AddForceToBall);
        addForceTimer.AddTimerFinishedEventListener(RestoreForceTimer);

        ballDeathTimer.AddTimerFinishedEventListener(KillTheBallAndSpawn);

        speedUpTimer.AddTimerFinishedEventListener(SpeedModeIsFinished);
    }

    

    public void SetDirection(Vector2 direction)
    {

        rb2d.velocity =  direction * rb2d.velocity.magnitude;
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

    void SpeedModeIsFinished()
    {
        isSpeedUp = false;
        speedUpTimer.ResetTimer();
        rb2d.velocity /= ConfigurationUtils.SpeedUpFactor;
    }

    void KillTheBallAndSpawn()
    {
        Destroy(gameObject);
        deadInScreen = true;
        if (HUD.ballsLeft > 0)
        {
            //spawnBallEvent.Invoke()
            ballSpawner.SpawnABall();
            updateBallsLeftEvent.Invoke();
            addForceTimer.Run();
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
                //SpawnBallEvent.Invoke()
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
