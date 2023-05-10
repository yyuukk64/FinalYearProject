using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Ivy : MonoBehaviour
{
    bool canCut = false;

    PlayerManager m_Player;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Player.Cuted_Ivy)
        {
            this.gameObject.SetActive(false);
            return;
        }

        m_Player = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canCut && Input.GetKeyDown(KeyCode.E) && m_Player.Passed_and_Get_Scissor)
        {
            this.gameObject.SetActive(false);
            m_Player.Cuted_Ivy = true;

            //save...
            m_Player.SavePlayer();

        }
        else if (canCut && Input.GetKeyDown(KeyCode.E))
        {
            //Dialogue...
            m_Player.activeEBtnCanvas(false);
            Debug.Log("You can't do it");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canCut = true;
            m_Player.activeEBtnCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_Player.activeEBtnCanvas(false);
        canCut = false;
    }
}
