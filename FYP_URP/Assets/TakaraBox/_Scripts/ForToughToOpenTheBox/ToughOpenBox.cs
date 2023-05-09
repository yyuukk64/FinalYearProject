using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughOpenBox : MonoBehaviour
{
    bool canOpen = false;

    private PlayerManager m_Player;

    public GameObject Player;

    [Header("Award")]
    public int getMoney = 0;
    public GameObject item = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E))
        {
            //Get Coins
            m_Player.AddMoney(getMoney);

            //Get Item 
            if(item == null)
            {
                return;
            }

            //Animation (Open the Box) ...

        }
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
