using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTheGame : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Update()
    {
     
        if(Input.GetKeyDown(KeyCode.Space))
        {            
                MenuManager.GoToMenu(MenuName.Pause);               
        }

    }


}
