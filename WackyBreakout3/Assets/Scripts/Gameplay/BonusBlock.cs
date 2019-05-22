using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


public class BonusBlock : Block
{
    
    
    void Start()
    {
        blockValue = ConfigurationUtils.BonusBlockPoints;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
