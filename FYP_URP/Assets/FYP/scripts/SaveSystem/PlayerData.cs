using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [Header("Player state")]
    public int health;
    public int maxHealth;

    public int attack;

    public int coin;

    public int[] Consumables = new int[7];

    [Header("Process")]
    public bool EnteredForest1_1 = false;
    public bool EnteredForest1_4 = false;
    public bool Passed_and_Get_Scissor = false;

    [Header("Location")]
    public string currentScene;
    public float[] position;

    public PlayerData (PlayerManager player)
    {
        //Save Player state
        health = player.health;
        maxHealth = player.maxHealth;
        attack = player.attack;
        coin = player.coin;
        Consumables = player.Consumables;

        //Save process...
        EnteredForest1_1 = player.EnteredForest1_1;
        EnteredForest1_4 = player.EnteredForest1_4;
        Passed_and_Get_Scissor = player.Passed_and_Get_Scissor;

        //Save location
        currentScene = player.currentScene;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
/*
    public void ResetPlayerData()
    {
        //Reset Player state
        health = 6;
        maxHealth = 6;
        attack = 1;
        coin = 0;
        for(int i = 0; 1 < 6; i++)
        {
            Consumables[i] = 0;
        }

        //Reset process


        //Reset location
        currentScene = "Lobby";
        position = new float[3];
        position[0] = 0;
        position[1] = 0;
        position[2] = 0;
    }
*/
}
