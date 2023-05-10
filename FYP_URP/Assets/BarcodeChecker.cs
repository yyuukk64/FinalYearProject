using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarcodeChecker : MonoBehaviour
{
    public string[] CleanWater;
    public string[] CupNoodles;

    PlayerManager m_Player;
    PauseMenuManager m_Pause;

    [SerializeField]
    Text txt_show;
    [SerializeField]
    InputField inputField;

    private void Start()
    {
        m_Player = FindObjectOfType<PlayerManager>();
        m_Pause = FindObjectOfType<PauseMenuManager>();
    }

    public void CheckCode(string result)
    {
        Debug.Log("Start!");
        for (int i = CleanWater.Length - 1; i >=0; i--)
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


                Debug.Log("Pass");
                m_Player.SavePlayer();

                Debug.Log("Pass2");
                return;
            }
        }

        Debug.Log("Complete");
    }

    public void CheckEnterCode(Text result)
    {
        for (int i = CleanWater.Length - 1; i >= 0; i--)
        {
            if (result.text == CleanWater[i])
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
            if (result.text == CupNoodles[i])
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

    public void ChangeShownText()
    {
        txt_show.text = inputField.text;
    }
}
