using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    PlayerManager m_player;

    [Header("Product")]
    public Button btn_UpMaxHealth;
    public int int_UpgrateCost = 200;
    public float flt_UpgrateRate = 1.5f;
    public TextMeshProUGUI txt_Cost;

    [Header("Item")]
    public Button btn_RecoverPosion;
    public int int_RecoverPosion = 100;

    public Button btn_GreatRecoverPosion;
    public int int_GreatRecoverPosion = 300;

    public Button btn_HyperRecoverPosion;
    public int int_HyperRecoverPosion = 700;

    [Space()]
    public Button btn_SpeedPosion;
    public int int_SpeedPosion = 150;

    public Button btn_GreatSpeedPosion;
    public int int_GreatSpeedPosion = 400;

    public Button btn_HyperSpeedPosion;
    public int int_HyperSpeedPosion = 800;

    private void Start()
    {
        m_player = FindObjectOfType<PlayerManager>();

        //Loading Player's MaxHealth to set the upgrate cost
        int_UpgrateCost = 200;
        for(int i = 6; i < m_player.maxHealth; i += 2)
        {
            int_UpgrateCost = Mathf.RoundToInt(int_UpgrateCost * flt_UpgrateRate);
        }

        txt_Cost.text = int_UpgrateCost.ToString();

        if(m_player.maxHealth >= 20)
        {
            btn_UpMaxHealth.interactable = false;
        }
    }

    public void UpgrateMaxHealth()
    {
        if (m_player.coin < int_UpgrateCost)
            return;

        //Pay money
        m_player.PayMoney(int_UpgrateCost);
        //update the cost
        int_UpgrateCost = Mathf.RoundToInt(int_UpgrateCost * flt_UpgrateRate);

        txt_Cost.text = int_UpgrateCost.ToString();

        //Upgrate Player's Maximun Health
        m_player.AddMaxHealth(2);

        //save
        m_player.SavePlayer();
    }

    public void BuyRecoverPosion()
    {
        if (m_player.coin < int_RecoverPosion)
            return;

        m_player.PayMoney(int_RecoverPosion);
        m_player.Consumables[0] += 1;
        m_player.SavePlayer();
    }

    public void BuyGreatRecoverPosion()
    {
        if (m_player.coin < int_GreatRecoverPosion)
            return;

        m_player.PayMoney(int_GreatRecoverPosion);
        m_player.Consumables[1] += 1;
        m_player.SavePlayer();
    }
    public void BuyHyperRecoverPosion()
    {
        if (m_player.coin < int_HyperRecoverPosion)
            return;

        m_player.PayMoney(int_HyperRecoverPosion);
        m_player.Consumables[2] += 1;
        m_player.SavePlayer();
    }
    public void BuySpeedPosion()
    {
        if (m_player.coin < int_SpeedPosion)
            return;

        m_player.PayMoney(int_SpeedPosion);
        m_player.Consumables[3] += 1;
        m_player.SavePlayer();
    }
    public void BuyGreatSpeedPosion()
    {
        if (m_player.coin < int_GreatSpeedPosion)
            return;

        m_player.PayMoney(int_GreatSpeedPosion);
        m_player.Consumables[4] += 1;
        m_player.SavePlayer();
    }
    public void BuyHyperSpeedPosion()
    {
        if (m_player.coin < int_HyperSpeedPosion)
            return;

        m_player.PayMoney(int_HyperSpeedPosion);
        m_player.Consumables[5] += 1;
        m_player.SavePlayer();
    }
}
