using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarilySave : Singleton<TemporarilySave>
{
    public int health;
    public int maxHealth;
    public int attack;
    public int coin;

    public int[] Consumables = new int[7];

    public int ScanCD;

    public string sceneBeforeBattle;
    public Vector3 posBeforeBattle;
    public Vector3 posForGate;

    //process
    public bool FirstIn;
    public bool EnteredForest1_1;
    public bool EnteredForest1_4;
    public bool Passed_and_Get_Scissor;
    public bool WinTheFirstBoss;
    public bool Cuted_Ivy;
    public bool FirstBeforeHouse;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void TemporarilyData(PlayerManager player)
    {
        health = player.health;
        maxHealth = player.maxHealth;
        attack = player.attack;
        coin = player.coin;

        for (int i = 0; i < 7; i++)
        {
            Consumables[i] = player.Consumables[i];
        }

        ScanCD = player.ScanCD;

        //process
        FirstIn = player.FirstIn;
        EnteredForest1_1 = player.EnteredForest1_1;
        EnteredForest1_4 = player.EnteredForest1_4;
        Passed_and_Get_Scissor = player.Passed_and_Get_Scissor;
        WinTheFirstBoss = player.WinTheFirstBoss;
        Cuted_Ivy = player.Cuted_Ivy;
        FirstBeforeHouse = player.FirstBeforeHouse;

        sceneBeforeBattle = player.currentScene;
        //posBeforeBattle = player.transform.position;

    }
}
