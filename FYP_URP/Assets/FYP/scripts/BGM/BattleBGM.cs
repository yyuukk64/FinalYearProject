using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBGM : BGMLoop
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BattleBGM");
    if( musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
}
