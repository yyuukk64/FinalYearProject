using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableMenu : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject RecoverPotion;
    [SerializeField] GameObject RecoverPotionx0;
    [SerializeField] GameObject GreatRecoverPotion;
    [SerializeField] GameObject GreatRecoverPotionx0;
    [SerializeField] GameObject HyperRecoverPotion;
    [SerializeField] GameObject HyperRecoverPotionx0;
    [SerializeField] GameObject SpeedPotion;
    [SerializeField] GameObject SpeedPotionx0;
    [SerializeField] GameObject GreatSpeedPotion;
    [SerializeField] GameObject GreatSpeedPotionx0;
    [SerializeField] GameObject HyperSpeedPotion;
    [SerializeField] GameObject HyperSpeedPotionx0;
    [SerializeField] GameObject ShieldCrystle;
    [SerializeField] GameObject ShieldCrystlex0;
    void Awake()
    {
        playerManager = Player.GetComponent<PlayerManager>();
    }

    public int[] Consumables = new int[7];

    // Update is called once per frame
    void Update()
    {
        Consumables[0] = playerManager.Consumables[0];
        if (Consumables[0] < 1)
        {
            RecoverPotion.SetActive(false);
            RecoverPotionx0.SetActive(true);
        }
        else
        {
            RecoverPotion.SetActive(true);
            RecoverPotionx0.SetActive(false);
        }

        Consumables[1] = playerManager.Consumables[1];
        if (Consumables[1] < 1)
        {
            GreatRecoverPotion.SetActive(false);
            GreatRecoverPotionx0.SetActive(true);
        }
        else
        {
            GreatRecoverPotion.SetActive(true);
            GreatRecoverPotionx0.SetActive(false);
        }

        Consumables[2] = playerManager.Consumables[2];
        if (Consumables[2] < 1)
        {
            HyperRecoverPotion.SetActive(false);
            HyperRecoverPotionx0.SetActive(true);
        }
        else
        {
            HyperRecoverPotion.SetActive(true);
            HyperRecoverPotionx0.SetActive(false);
        }

        Consumables[3] = playerManager.Consumables[3];
        if (Consumables[3] < 1)
        {
            SpeedPotion.SetActive(false);
            SpeedPotionx0.SetActive(true);
        }
        else
        {
            SpeedPotion.SetActive(true);
            SpeedPotionx0.SetActive(false);
        }

        Consumables[4] = playerManager.Consumables[4];
        if (Consumables[4] < 1)
        {
            GreatSpeedPotion.SetActive(false);
            GreatSpeedPotionx0.SetActive(true);
        }
        else
        {
            GreatSpeedPotion.SetActive(true);
            GreatSpeedPotionx0.SetActive(false);
        }

        Consumables[5] = playerManager.Consumables[5];
        if (Consumables[5] < 1)
        {
            HyperSpeedPotion.SetActive(false);
            HyperSpeedPotionx0.SetActive(true);
        }
        else
        {
            HyperSpeedPotion.SetActive(true);
            HyperSpeedPotionx0.SetActive(false);
        }

        Consumables[6] = playerManager.Consumables[6];
        if (Consumables[6] < 1)
        {
            ShieldCrystle.SetActive(false);
            ShieldCrystlex0.SetActive(true);
        }
        else
        {
            ShieldCrystle.SetActive(true);
            ShieldCrystlex0.SetActive(false);
        }
    }
}

