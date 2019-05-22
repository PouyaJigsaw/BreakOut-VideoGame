using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{

    static ConfigurationData ConfigData;
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return ConfigData.PaddleMoveUnitsPerSecond; }

    }

    public static float BallImpulseForce
    {
        get { return ConfigData.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return ConfigData.BallLifeTime; }
    }

    public static float MinSpawnSecond
    {
        get { return ConfigData.MinSpawnSecond;  }

    }

    public static float MaxSpawnSecond
    {
        get { return ConfigData.MaxSpawnSecond;  }
    }

    public static float StandardBlockPoints
    {
        get { return ConfigData.StandardBlockPoints;  }
    }

    public static float BonusBlockPoints
    {
        get { return ConfigData.BonusBlockPoints; }
    }

    public static float PickUpBlockPoints
    {
        get { return ConfigData.PickUpBlockPoints;  }
    }

    public static float StandardBlockProbability
    {
        get { return ConfigData.StandardBlockProbability; }
    }

    public static float BonusBlockProbability
    {
        get { return ConfigData.BonusBlockProbability; }
    }

    public static float PickUpBlockProbability
    {
        get { return ConfigData.PickUpBlockProbability;  }
    }

    public static float BallsLeft
    {
        get { return ConfigData.NumOfBallsLeft; }
    }

    public static float FreezerEffectDuration
    {
        get { return ConfigData.FreezeEffectDuration; }
    }

    public static float SpeedUpEffectDuration
    {
        get { return ConfigData.SpeedUpEffectDuration; }
    }

    public static float SpeedUpFactor
    {
        get { return ConfigData.SpeedUpFactor;  }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        ConfigData = new ConfigurationData();
    }
}
