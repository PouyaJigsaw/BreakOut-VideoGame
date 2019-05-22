using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffectMonitor : MonoBehaviour
{
    bool isSpeedUpMonitor;
    Timer speedUpTimerMonitor;
    float speedUpDurationMonitor;
    float speedUpFactorMonitor;

    #region Properties

    public bool IsSpeedMonitor
    {
        get { return isSpeedUpMonitor;  }
    }

    public float timerRemain
    {
        get { return speedUpTimerMonitor.TimeRemainAfterRun;  }
    }
    #endregion


    
    #region Methods
    private void Start()
    {
        isSpeedUpMonitor = false;
        speedUpTimerMonitor = gameObject.AddComponent<Timer>();
        speedUpDurationMonitor = ConfigurationUtils.SpeedUpEffectDuration;
        speedUpFactorMonitor = ConfigurationUtils.SpeedUpFactor;


        EventManager.AddSpeedUpListener(Initialize);
       
    }

    private void Update()
    {
        if(speedUpTimerMonitor.Finished)
        {
            isSpeedUpMonitor = false;
            speedUpTimerMonitor.ResetTimer();
        }
    }

    void Initialize(float speedUpDuration, float speedUpFactor)
    {
        
        if (isSpeedUpMonitor == false)
        {

            speedUpDurationMonitor = speedUpDuration;
            speedUpFactorMonitor = speedUpFactor;
            isSpeedUpMonitor = true;
            speedUpTimerMonitor.Duration = speedUpDuration;
            speedUpTimerMonitor.Run();
        }
        else
        {
            speedUpTimerMonitor.AddSeconds(speedUpDuration);

        }
    }


    #endregion
}
