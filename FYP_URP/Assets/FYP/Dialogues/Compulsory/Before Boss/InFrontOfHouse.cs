using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFrontOfHouse : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] GameObject StoyrObject;

    //Script
    PlayerManager m_Player;
    TemporarilySave m_temporarilySave;

    private void Awake()
    {
        m_Player = FindObjectOfType<PlayerManager>();
        m_temporarilySave = FindObjectOfType<TemporarilySave>();

        if (m_temporarilySave.FirstBeforeHouse)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !m_Player.FirstBeforeHouse)
        {
            m_Player.FirstBeforeHouse = true;
            Instantiate(StoyrObject);
            Destroy(this.gameObject);
        }
    }
}
