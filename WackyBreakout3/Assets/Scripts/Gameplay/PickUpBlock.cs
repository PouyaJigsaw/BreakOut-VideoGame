using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpBlock : Block
{
    [SerializeField]
    Sprite freezeBlock;
    [SerializeField]
    Sprite speedUpBlock;

    PickupEffect pickUpType;

    // duration for events
    float freezerEffectDuration;
    float speedUpEffectDuration;
    float speedUpFactor;
    //events
    FreezerEffectActivated freezerEffectActivated;
    SpeedUpEffectActivated speedUpEffectActivated;

    public PickupEffect PickUpType
    {
        set
        {
            pickUpType = value;
            if(pickUpType == PickupEffect.Freezer)
                {               
                    freezerEffectActivated = new FreezerEffectActivated();
                    freezerEffectDuration = ConfigurationUtils.FreezerEffectDuration;
                    EventManager.AddFreezerInvoker(this);
                }
            else
                {
                    speedUpEffectActivated = new SpeedUpEffectActivated();
                    speedUpEffectDuration = ConfigurationUtils.SpeedUpEffectDuration;
                    speedUpFactor = ConfigurationUtils.SpeedUpFactor;
                    EventManager.AddSpeedUpInvoker(this);


                    
                }

         
        }

        get
        {
            return PickUpType;
        }

        

    }
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        blockValue = ConfigurationUtils.PickUpBlockPoints;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        int num = Random.Range(0, 2);
        if (num == 0) { sr.sprite = freezeBlock; PickUpType = PickupEffect.Freezer; }
        else { sr.sprite = speedUpBlock; PickUpType = PickupEffect.Speedup; }


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void  AddFreezerEffectListener (UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedUpEffectListener(UnityAction<float,float> listener)
    {
        speedUpEffectActivated.AddListener(listener);
    }


    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if(pickUpType == PickupEffect.Freezer)
        {
            freezerEffectActivated.Invoke(freezerEffectDuration);
        }

        else
        {

            speedUpEffectActivated.Invoke(speedUpEffectDuration, speedUpFactor);
        }
    }
}

