using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 50;
    static float ballImpulseForce = 70000;
    static float ballLifeTime = 10f;
    static float minSpawnSecond = 5f;
    static float maxSpawnSecond = 10f;
    static float standardBlockPoints = 1;
    static float bonusBlockPoints = 2;
    static float pickUpBlockPoints = 5;
    static float standardBlockProbability = 0.7f;
    static float bonusBlockProbability = 0.2f;
    static float pickUpBlockProbability = 0.1f;
    static float numOfBallsLeft = 5;
    static float freezerEffectDuration = 2f;
    static float speedUpDuration = 2f;
    static float speedUpFactor = 2f;



    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    public float MinSpawnSecond
    {
        get { return minSpawnSecond; }
    }

    public float MaxSpawnSecond
    {
        get { return maxSpawnSecond;  }
    }

    public float StandardBlockPoints
    {
        get { return standardBlockPoints;  }
    }

    public float BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public float PickUpBlockPoints
    {
        get { return pickUpBlockPoints;  }
    }

    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    public float PickUpBlockProbability
    {
        get { return pickUpBlockProbability;  }
    }

    public float NumOfBallsLeft
    {
        get { return numOfBallsLeft; }
    }

    public float FreezeEffectDuration
    {
        get { return freezerEffectDuration;  }
    }

    public float SpeedUpEffectDuration
    {
        get { return speedUpDuration; }
    }

    public float SpeedUpFactor
    {
        get { return speedUpFactor; }
    }
    #endregion


    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input;
        input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

        try
        {
            string[] names = input.ReadLine().Split(',');
            string[] values = input.ReadLine().Split(',');

            ConfigurationDataFields(values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if(input != null)
            {
                input.Close();
            }
        }
      

    }


    void ConfigurationDataFields(string[] csvValues)
    {
        ConfigurationData.paddleMoveUnitsPerSecond = float.Parse(csvValues[0]);
        ConfigurationData.ballImpulseForce = float.Parse(csvValues[1]);
        //ConfigurationData.ballLifeTime = float.Parse(csvValues[2]);
        //ConfigurationData.minSpawnSecond = float.Parse(csvValues[3]);
        //ConfigurationData.maxSpawnSecond = float.Parse(csvValues[4]);
    }



    #endregion
}
