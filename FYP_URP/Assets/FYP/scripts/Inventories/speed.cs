using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerManager playerManager;
    [SerializeField] GameObject Player;
    [SerializeField] float amount;
    [SerializeField] int array;
    void Awake()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        playerManager = Player.GetComponent<PlayerManager>();
    }

    public void use()
    {
        if (playerManager.Consumables[array] >= 1)
        {
            playerMovement.moveSpeed = amount;
            Invoke(nameof(slow), 10.0f);
            playerManager.Consumables[array] -= 1;
        }
        else
            Debug.Log("less then one u dumb dumb");

    }
    public void slow()
    {
        playerMovement.moveSpeed = 10;
    }
}

