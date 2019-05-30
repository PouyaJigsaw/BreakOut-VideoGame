using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{

    protected float blockValue;
    PointsAddedEvent pointsAddedEvent;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        pointsAddedEvent = new PointsAddedEvent();
        EventManager.AddPointsAddedEventInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void  OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.BlockDestroy);
        Destroy(gameObject);
        pointsAddedEvent.Invoke(blockValue);
    }


    public void AddPointsAddedListener(UnityAction<float> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }
}
