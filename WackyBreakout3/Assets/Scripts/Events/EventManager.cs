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


    #region Points Added Event
    static Block pointsAddedInvoker = new Block();
    static List<UnityAction<float>> pointsAddedListenerList = new List<UnityAction<float>>();
    
    public static void  AddPointsAddedEventListener(UnityAction<float> listener)
    {
        pointsAddedListenerList.Add(listener);
        
        if( pointsAddedInvoker != null)
        {
            pointsAddedInvoker.AddPointsAddedListener(listener);
        }
    }

    public static void AddPointsAddedEventInvoker(Block invoker)
    {
        pointsAddedInvoker = invoker;

        foreach(UnityAction<float> pointsAddedListener in pointsAddedListenerList)
        {
            pointsAddedInvoker.AddPointsAddedListener(pointsAddedListener);
        }

    }
    #endregion


    #region Update Balls Left Event

    static List<Ball> updateBallsLeftInvokerList = new List<Ball>();
    static UnityAction updateBallsLeftListener;

    public static void AddUpdateBallsLeftInvoker(Ball invoker)
    {
        updateBallsLeftInvokerList.Add(invoker);

        if (updateBallsLeftListener != null)
            invoker.AddUpdateBallsLeftListener(updateBallsLeftListener);

    }

    public static void AddUpdateBallsLeftListener(UnityAction listener)
    {
        updateBallsLeftListener = listener;

        foreach(Ball updateBallsLeftInvoker in updateBallsLeftInvokerList)
        {
            updateBallsLeftInvoker.AddUpdateBallsLeftListener(listener);
        }
    }



    #endregion


    #region Ball Dies Event

    static List<Ball> ballDiesInvokerList = new List<Ball>();
    static UnityAction ballDiesListener;


    public static void AddBallDiesInvoker(Ball invoker)
    {
        ballDiesInvokerList.Add(invoker);
        
        if(ballDiesListener != null)
        {
            invoker.AddUpdateBallsLeftListener(ballDiesListener);
        }
    }


    public static void AddBallDiesListener(UnityAction listener)
    {
        ballDiesListener = listener;

        foreach(Ball ballDiesInvoker in ballDiesInvokerList)
        {
            ballDiesInvoker.AddBallDiesListener(ballDiesListener);
        }
    }


    #endregion


}
