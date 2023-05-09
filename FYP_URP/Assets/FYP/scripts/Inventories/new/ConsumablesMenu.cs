using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesMenu : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject Player;

    void Awake()
    {
        playerManager = Player.GetComponent<PlayerManager>();
    }

    public GameObject ConsumableUI1;
    public GameObject ConsumableUI1Disabled;

    public GameObject ConsumableUI2;
    public GameObject ConsumableUI2Disabled;

    public GameObject ConsumableUI3;
    public GameObject ConsumableUI3Disabled;

    public GameObject ConsumableUI4;
    public GameObject ConsumableUI4Disabled;

    public GameObject ConsumableUI5;
    public GameObject ConsumableUI5Disabled;

    public GameObject ConsumableUI6;
    public GameObject ConsumableUI6Disabled;

    public GameObject ConsumableUI7;
    public GameObject ConsumableUI7Disabled;

    public int[] Consumable = new int[7];

    void Update()
    {
        Consumable[0] = playerManager.Consumables[0];

        if(Consumable[0] < 1)
        {
            ConsumableUI1.SetActive(false);
            ConsumableUI1Disabled.SetActive(true);
        }
        else
        {
            ConsumableUI1.SetActive(true);
            ConsumableUI1Disabled.SetActive(false);
        }

        Consumable[1] = playerManager.Consumables[1];
        if (Consumable[1] < 1)
        {
            ConsumableUI2.SetActive(false);
            ConsumableUI2Disabled.SetActive(true);
        }
        else
        {
            ConsumableUI2.SetActive(true);
            ConsumableUI2Disabled.SetActive(false);
        }

        Consumable[2] = playerManager.Consumables[2];

        if (Consumable[2] < 1)
        {
            ConsumableUI3.SetActive(false);
            ConsumableUI3Disabled.SetActive(true);
        }
        else
        {
            ConsumableUI3.SetActive(true);
            ConsumableUI3Disabled.SetActive(false);
        }

        Consumable[3] = playerManager.Consumables[3];

        if (Consumable[3] < 1)
        {
            ConsumableUI4.SetActive(false);
            ConsumableUI4Disabled.SetActive(true);
        }
        else
        {
            ConsumableUI4.SetActive(true);
            ConsumableUI4Disabled.SetActive(false);
        }

        Consumable[4] = playerManager.Consumables[4];

        if (Consumable[4] < 1)
        {
            ConsumableUI5.SetActive(false);
            ConsumableUI5Disabled.SetActive(true);
        }
        else
        {
            ConsumableUI5.SetActive(true);
            ConsumableUI5Disabled.SetActive(false);
        }

        Consumable[5] = playerManager.Consumables[5];

        if (Consumable[5] < 1)
        {
            ConsumableUI6.SetActive(false);
            ConsumableUI6Disabled.SetActive(true);
        }
        else
        {
            ConsumableUI6.SetActive(true);
            ConsumableUI6Disabled.SetActive(false);
        }

        Consumable[6] = playerManager.Consumables[6];

        if (Consumable[6] < 1)
        {
            ConsumableUI7.SetActive(false);
            ConsumableUI7Disabled.SetActive(true);
        }
        else
        {
            ConsumableUI7.SetActive(true);
            ConsumableUI7Disabled.SetActive(false);
        }
    }

}
