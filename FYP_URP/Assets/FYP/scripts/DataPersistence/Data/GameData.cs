using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int health;
    public Vector3 playerPosition;
    public AttributesData playerAttributesData;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        this.health = 6;
        playerPosition = new Vector3(-11.5f, 1.53f, -71.1f);
        playerAttributesData = new AttributesData();
    }
}
