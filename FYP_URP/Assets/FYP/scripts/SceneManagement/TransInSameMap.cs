using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransInSameMap : MonoBehaviour
{
    public GameObject Player;

    bool canTeleport = false;
    public Vector3 position;

    private PlayerManager m_Player;

    // Update is called once per frame
    void Update()
    {
        if(canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            Player.transform.position = position;

            //animation...
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canTeleport = true; 
            m_Player = Player.GetComponent<PlayerManager>();
            m_Player.activeEBtnCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canTeleport = false;
            m_Player.activeEBtnCanvas(false);
        }
    }
}
