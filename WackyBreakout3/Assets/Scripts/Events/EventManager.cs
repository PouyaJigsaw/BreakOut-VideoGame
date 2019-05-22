using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Freezer Event
    static List<PickUpBlock> freezerInvokerList = new List<PickUpBlock>();
    static UnityAction<float> freezerListener;


    public static void AddFreezerInvoker(PickUpBlock invoker)
    {
        freezerInvokerList.Add(invoker);
        if(freezerListener != null)
        {
            invoker.AddFreezerEffectListener(freezerListener);
            

        }
    }

    public static void AddFreezerListener(UnityAction<float> listener)
    {
        freezerListener = listener;
        if(freezerInvokerList != null)
        {
            foreach (PickUpBlock freezerInvoker in freezerInvokerList)
            {
                freezerInvoker.AddFreezerEffectListener(freezerListener);
            }
        }
    }



    #endregion


    # region Speed Up Event

    static List<PickUpBlock> speedUpInvokerList = new List<PickUpBlock>();
    static List<UnityAction<float,float>> speedUpListenerList = new List<UnityAction<float,float>>();


    public static  void AddSpeedUpInvoker(PickUpBlock invoker)
    {
        speedUpInvokerList.Add(invoker);
        
        foreach(UnityAction<float,float> speedUpListener in speedUpListenerList)
        {
            invoker.AddSpeedUpEffectListener(speedUpListener);
        }

    }


    public static void AddSpeedUpListener(UnityAction<float,float> listener)
    {
        speedUpListenerList.Add(listener);

        foreach(PickUpBlock speedInvoker in speedUpInvokerList)
        {
            speedInvoker.AddSpeedUpEffectListener(listener);
        }
    }

    

#endregion
}
