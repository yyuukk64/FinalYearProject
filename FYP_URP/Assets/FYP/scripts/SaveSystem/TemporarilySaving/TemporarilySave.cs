using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarilySave : Singleton<TemporarilySave>
{
    public int health;
    public int maxHealth;
    public int coin;

    public float[] posBeforeBattle = new float[3];
    public float[] posForGate = new float[3];

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public TemporarilySave(PlayerManager player)
    {
        health = player.health;
        maxHealth = player.maxHealth;
        coin = player.coin;

        posBeforeBattle[0] = player.transform.position.x;
        posBeforeBattle[1] = player.transform.position.y;
        posBeforeBattle[2] = player.transform.position.z;
    }
}
