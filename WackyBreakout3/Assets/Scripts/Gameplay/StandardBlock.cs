using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


    class StandardBlock : Block
    {
    [SerializeField]
    Sprite standardBlock1;
    [SerializeField]
    Sprite standardBlock2;
    [SerializeField]
    Sprite standardBlock3;

    Sprite toBeBlock;

        private void Start()
        {
            blockValue = ConfigurationUtils.StandardBlockPoints;

            int randomNum = Random.Range(0, 3);
            
            switch(randomNum)
            {
                case 0: toBeBlock = standardBlock1; break;
                case 1: toBeBlock = standardBlock2; break;
                case 2: toBeBlock = standardBlock3; break;
            }

            SpriteRenderer sR = GetComponent<SpriteRenderer>();
            sR.sprite = toBeBlock;

        }

        

    }


