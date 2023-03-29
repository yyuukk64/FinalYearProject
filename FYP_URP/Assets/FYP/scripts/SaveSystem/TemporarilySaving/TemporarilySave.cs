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
    }
}
