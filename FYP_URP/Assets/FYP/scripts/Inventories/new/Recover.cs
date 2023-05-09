using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject Player;
    [SerializeField] int amount;
    [SerializeField] int array;
    void Awake()
    {
        playerManager = Player.GetComponent<PlayerManager>();
    }

    public void use()
    {
        if (playerManager.Consumables[array] >= 1)
        {
            playerManager.health += amount;
            playerManager.Consumables[array] -= 1;
        }else
            Debug.Log("less then one u dumb dumb");

    }
}
