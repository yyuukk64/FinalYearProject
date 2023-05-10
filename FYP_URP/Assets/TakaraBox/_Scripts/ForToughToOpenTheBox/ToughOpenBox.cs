using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToughOpenBox : MonoBehaviour
{
    bool canOpen = false;
    bool Opened = false;

    private PlayerManager m_Player;

    public GameObject Player;

    [Header("Award")]
    public int getMoney = 0;
    public GameObject item = null;

    public GameObject Notice;

    // Update is called once per frame
    void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E) && !Opened)
        {
            Opened = true;

            //Get Coins
            m_Player.AddMoney(getMoney);

            //Get Item 
            if(item == null)
            {
                return;
            }

            Notice.SetActive(true);

            //Animation (Open the Box) ...

        }
    }

    public void closeNotice()
    {
        Notice.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canOpen = true;
            m_Player = Player.GetComponent<PlayerManager>();
            m_Player.activeEBtnCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canOpen = false;
            m_Player.activeEBtnCanvas(false);
        }
    }
}
