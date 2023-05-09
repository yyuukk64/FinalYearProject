using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker_Forest1_4 : MonoBehaviour
{
    PlayerManager m_Player;

    [SerializeField] GameObject StoryObject;

    private void Start()
    {
        m_Player = FindObjectOfType<PlayerManager>();

        if (!m_Player.EnteredForest1_4)
        {
            m_Player.EnteredForest1_4 = true;
            Instantiate(StoryObject);
        }
    }
}
