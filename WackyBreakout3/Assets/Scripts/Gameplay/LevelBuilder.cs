using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    [SerializeField]
    GameObject standardBlockPrefab;
    [SerializeField]
    GameObject paddlePrefab;
    [SerializeField]
    GameObject bonusBlockPrefab;
    [SerializeField]
    GameObject pickUpBlockPrefab;

    float blockWidth;
    float blockHeight;
    BoxCollider2D blockCol2D;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddlePrefab, new Vector2(0, -1252), Quaternion.identity);

        GameObject blockTemp = Instantiate(standardBlockPrefab, Vector3.zero, Quaternion.identity);
        blockCol2D = blockTemp.GetComponent<BoxCollider2D>();
        blockWidth = blockCol2D.size.x;
        blockHeight = blockCol2D.size.y;
        Destroy(blockTemp);

        InitializeRows();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void InitializeRows()
    {
        float firstRowY = 1343;
        float secondRowY = firstRowY - blockHeight;
        float thirdRowY = secondRowY - blockHeight;
        

        int numOfBlockInRow = (int)((ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / blockWidth);          
        float rowX = ScreenUtils.ScreenLeft + blockWidth / 2;
        
        float endRowX = rowX;
        for( int i = 0; i < numOfBlockInRow; i++)
        {
            endRowX += blockWidth;
        }       
        float offset = (ScreenUtils.ScreenRight -  endRowX);
        rowX += offset;
        for (int i = 0; i < numOfBlockInRow; i++)
        {
            Instantiate(RandomBlock(), new Vector2(rowX, firstRowY), Quaternion.identity);
            Instantiate(RandomBlock(), new Vector2(rowX, secondRowY), Quaternion.identity);
           

            rowX += blockWidth;
        }

      



    }


    GameObject RandomBlock()
    {
        float sBlockP = ConfigurationUtils.StandardBlockProbability;
        float bBlockP = sBlockP + ConfigurationUtils.BonusBlockProbability;
        float pBlockP = bBlockP + ConfigurationUtils.PickUpBlockProbability;

         double randomNum = Random.Range(0, 1.0000001f);
       
        if(randomNum <= sBlockP)
        {
            return standardBlockPrefab;
        }
        else if(randomNum <= bBlockP)
        {
            return bonusBlockPrefab;
        }
        else { return pickUpBlockPrefab;  }
        
    }

}
