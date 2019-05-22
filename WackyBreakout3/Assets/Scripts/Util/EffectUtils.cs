using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    static SpeedUpEffectMonitor speedUpEffectMonitor;

    public static bool IsSpeedUp
        {
        get { return speedUpEffectMonitor.IsSpeedMonitor;  }
        }

    public static float speedUpTimerRemain
    {
        get { return speedUpEffectMonitor.timerRemain;  }
    }
    
    public static void Initialize()
    {
        speedUpEffectMonitor = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SpeedUpEffectMonitor>(); 
    }


}
