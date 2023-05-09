using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcodeChecker : MonoBehaviour
{
    public string[] CleanWater;
    public string[] CupNoodles;

    PlayerManager m_Player;
    PauseMenuManager m_Pause;

    private void Start()
    {
        m_Player = FindObjectOfType<PlayerManager>();
        m_Pause = FindObjectOfType<PauseMenuManager>();
    }

    public void CheckCode(string result)
    {
        for(int i = CleanWater.Length - 1; i >=0; i--)
        {
            if(result == CleanWater[i])
            {
                m_Player.Consumables[0] += 1;
                m_Player.cannotScan();

                //close the camera
                m_Pause.closeBarcodeReader();

                m_Player.SavePlayer();
                return;
            }
        }

        for (int i = CupNoodles.Length - 1; i >= 0; i--)
        {
            if (result == CupNoodles[i])
            {
                m_Player.Consumables[1] += 1;
                m_Player.cannotScan();

                //close the camera
                m_Pause.closeBarcodeReader();

                m_Player.SavePlayer();
                return;
            }
        }
    }
}
