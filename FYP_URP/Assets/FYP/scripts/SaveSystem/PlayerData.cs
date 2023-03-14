using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int maxHealth;
    public int coin;
    public string currentScene;
    public float[] position;

    public PlayerData (PlayerManager player)
    {
        health = player.health;
        maxHealth = player.maxHealth;
        coin = player.coin;

        currentScene = player.currentScene;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}