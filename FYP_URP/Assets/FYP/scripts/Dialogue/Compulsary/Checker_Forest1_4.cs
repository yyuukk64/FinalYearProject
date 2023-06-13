using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker_Forest1_4 : MonoBehaviour
{
    PlayerManager m_Player;
    SceneChangingManager m_Scene;

    [SerializeField] GameObject StoryObject;

    private void Start()
    {
        m_Player = FindObjectOfType<PlayerManager>();
        m_Scene = FindObjectOfType<SceneChangingManager>();

        m_Scene.canChange = false;

        if (!m_Player.EnteredForest1_4)
        {
            m_Player.EnteredForest1_4 = true;
            Instantiate(StoryObject);
            Debug.LogError("The state of EnteredForest1_4 is " + m_Player.EnteredForest1_4.ToString());
        }
        
    }
}
