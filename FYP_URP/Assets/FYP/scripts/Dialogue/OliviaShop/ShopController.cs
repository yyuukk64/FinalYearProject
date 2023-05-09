using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    PlayerManager m_player;

    [Header("Product")]
    public Button btn_UpMaxHealth;
    public int int_UpgrateCost = 200;
    public static float flt_UpgrateRate = 1.5f;

    [Header("Item")]
    public Button btn_RecoverPosion;
    public Button btn_GreatRecoverPosion;
    public Button btn_HyperRecoverPosion;

    [Space()]
    public Button btn_SpeedPosion;
    public Button btn_GreatSpeedPosion;
    public Button btn_HyperSpeedPosion;

    private void Start()
    {
        m_player = FindObjectOfType<PlayerManager>();

        //Loading Player's MaxHealth to set the upgrate cost
        int_UpgrateCost = 200;
        for(int i = 6; i < m_player.maxHealth; i += 2)
        {
            int_UpgrateCost = Mathf.RoundToInt(int_UpgrateCost * flt_UpgrateRate);
        }

        if(m_player.maxHealth >= 20)
        {
            btn_UpMaxHealth.interactable = false;
        }
    }

    public void UpgrateMaxHealth()
    {
        //Pay money
        m_player.PayMoney(int_UpgrateCost);
        //update the cost
        int_UpgrateCost = Mathf.RoundToInt(int_UpgrateCost * flt_UpgrateRate);

        //Upgrate Player's Maximun Health
        m_player.AddMaxHealth(2);

        //save
        m_player.SavePlayer();
    }
}
