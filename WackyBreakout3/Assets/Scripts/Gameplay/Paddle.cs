using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2d;
    float colliderHalfWidth;
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
    float colliderHalfHeight;
    bool isFrozen = false;

    Timer freezeTimer;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        colliderHalfWidth = GetComponent<BoxCollider2D>().size.x / 2;
        colliderHalfHeight = GetComponent<BoxCollider2D>().size.y / 2;
        freezeTimer = gameObject.AddComponent<Timer>();

        EventManager.AddFreezerListener(freezeThePaddle);

        freezeTimer.AddTimerFinishedEventListener(FreezeModeFinished);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput != 0 && !isFrozen)
        {
            Vector2 currentPosition = transform.position;
            currentPosition.x = CalculateClampedX(currentPosition.x);
           
            Vector2 translate = new Vector2(horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond, 0);
            rb2d.MovePosition(currentPosition + translate);
        }


    }

    float CalculateClampedX(float possibleX)
    {
        float newX = possibleX;

        if(possibleX - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            newX = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (possibleX + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            newX = ScreenUtils.ScreenRight - colliderHalfWidth;
        }

        return newX;
    }

    private void Update()
    {
       
       
        
        
    }

    void FreezeModeFinished()
    {
        isFrozen = false;
        freezeTimer.ResetTimer();
    }
    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && isCollisionTop(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                colliderHalfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            
            float angleSine = Mathf.Sin(angle);
            if(angleSine < 0)
            {
                angleSine *= -1;
            }
            Vector2 direction = new Vector2(Mathf.Cos(angle), angleSine);
            
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool isCollisionTop(Collision2D coll)
    {
        float range = transform.position.y + colliderHalfHeight + (coll.collider.bounds.size.y / 2);
        if (coll.gameObject.transform.position.y < range)
        {
            return false;
        }
        else return true;
    }


    void freezeThePaddle(float freezeDuration)
    {
        if (isFrozen == true)
        {
            freezeTimer.AddSeconds(freezeDuration);
        }
        else
        {
            isFrozen = true;
            freezeTimer.Duration = freezeDuration;
            freezeTimer.Run();
        }
    }
}
