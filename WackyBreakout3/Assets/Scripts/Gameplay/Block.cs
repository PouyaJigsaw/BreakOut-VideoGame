using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{

    protected float blockValue;
    PointsAddedEvent pointsAddedEvent;
    static LastBlockDestroyedEvent lastBlockDestroyed;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        lastBlockDestroyed = new LastBlockDestroyedEvent();
        pointsAddedEvent = new PointsAddedEvent();
        EventManager.AddPointsAddedEventInvoker(this);
        EventManager.AddLastBlockDestroyedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void  OnCollisionEnter2D(Collision2D collision)
    {
        LevelBuilder.numOfBlocks--;
        if(LevelBuilder.numOfBlocks == 0)
        {
            lastBlockDestroyed.Invoke();
        }
        AudioManager.Play(AudioClipName.BlockDestroy);
        Destroy(gameObject);
        pointsAddedEvent.Invoke(blockValue);
    }


    public void AddPointsAddedListener(UnityAction<float> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }


    public void AddLastBlockDestroyListener(UnityAction listener)
    {
        lastBlockDestroyed.AddListener(listener);
    }

}

