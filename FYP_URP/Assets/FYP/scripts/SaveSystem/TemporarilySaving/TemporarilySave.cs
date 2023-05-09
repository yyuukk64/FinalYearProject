using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarilySave : Singleton<TemporarilySave>
{
    public int health;
    public int maxHealth;
    public int attack;
    public int coin;

    public string sceneBeforeBattle;
    public Vector3 posBeforeBattle;
    public Vector3 posForGate;

    //process
    public bool EnteredForest1_1;
    public bool EnteredForest1_4;
    public bool Passed_and_Get_Scissor;

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

        sceneBeforeBattle = player.currentScene;
        //posBeforeBattle = player.transform.position;

        EnteredForest1_1 = player.EnteredForest1_1;
        EnteredForest1_4 = player.EnteredForest1_4;
        Passed_and_Get_Scissor = player.Passed_and_Get_Scissor;
    }
}
