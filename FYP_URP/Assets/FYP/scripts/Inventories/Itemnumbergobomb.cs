using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemnumbergobomb : MonoBehaviour
{

    //This part read the player

        PlayerManager playerManager;
        [SerializeField] GameObject Player;
        void Awake()
        {
            playerManager = Player.GetComponent<PlayerManager>();
        }

    //add the number of Consumables 1 (Recover Potion)

    void Update()
        {
            playerManager.Consumables[0] += 1;
        }
}
