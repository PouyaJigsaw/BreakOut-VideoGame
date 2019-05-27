using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject ball;



    Timer spawnSeconds;
    bool firstTime = true; // ummmmm, why?
    float spawnX, spawnY;
    BoxCollider2D boxCol2D;
    Vector2 colliderLowerLeft;
    Vector2 colliderUpperRight;
    

   
    private void Start()
    {
        
        GameObject ballTemp = Instantiate(ball, Vector3.zero, Quaternion.identity);
        boxCol2D = ballTemp.GetComponent<BoxCollider2D>();
        colliderLowerLeft = (Vector2)transform.position - new Vector2(boxCol2D.size.x/2, boxCol2D.size.y/2);
        colliderUpperRight = (Vector2)transform.position + new Vector2(boxCol2D.size.x/2, boxCol2D.size.y/2);
        Destroy(ballTemp);




        SpawnBallAndResetTimer();
        spawnSeconds.AddTimerFinishedEventListener(SpawnBallAndResetTimer);
    }
    

    void SpawnBallAndResetTimer()
    {
        if (HUD.ballsLeft > 0)
        {
            SpawnABall();
            spawnSeconds.Duration = Random.Range(ConfigurationUtils.MinSpawnSecond, ConfigurationUtils.MaxSpawnSecond);
            spawnSeconds.Run();
           
        }
    }


    public void SpawnABall()
    {

             
        GameObject ballSpawn = Instantiate(ball,RandomPosition(), Quaternion.identity);
        while(Physics2D.OverlapArea(colliderLowerLeft, colliderUpperRight) != null)
        {
            Destroy(ballSpawn);
            ballSpawn = Instantiate(ball, RandomPosition(), Quaternion.identity);
            Debug.Log("trying again!");
        }

               
    }

    Vector2 RandomPosition()
    {
        //should change that so no spawn below paddle and near blocks
        spawnX = Random.Range(-1000, 1000);
        spawnY = Random.Range(-1100, 1070);

        Vector2 positionSpawn = new Vector2(spawnX, spawnY);

        return positionSpawn;
    }

   
    
}
