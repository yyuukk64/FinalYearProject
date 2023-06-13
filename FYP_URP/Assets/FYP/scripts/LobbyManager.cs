using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] GameObject BeginningStory;

    SceneChangingManager m_SceneChangingManager;
    PlayerManager m_Player ;

    // Start is called before the first frame update
    void Start()
    {
        //Init
        m_SceneChangingManager = FindObjectOfType<SceneChangingManager>();
        m_Player = FindObjectOfType<PlayerManager>();
        m_Player.Init();
        m_Player.LoadOnSceneLoaded();
        m_Player.gameObject.transform.position = new Vector3(0f, 1.53f, -70f);
        m_Player.health = m_Player.maxHealth;

        if (m_SceneChangingManager.Load)
        {
            m_Player.LoadOnLoadGame();            
        }

        if (!m_Player.FirstIn)
        {
            m_Player.FirstIn = true;
            Instantiate(BeginningStory);
        }

        m_SceneChangingManager.canChange = false;
    }
}
