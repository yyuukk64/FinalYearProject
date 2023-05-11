using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildManager : MonoBehaviour
{
    MeetEnemy m_meetEnemy;
    SceneChangingManager m_SceneChangingManager;
    PlayerManager m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_meetEnemy = this.GetComponent<MeetEnemy>();
        m_SceneChangingManager = FindObjectOfType<SceneChangingManager>();
        m_Player = FindObjectOfType<PlayerManager>();

        m_Player.Init();

        //load Temporarily data

        if (m_SceneChangingManager.Load)
        {
            m_Player.LoadOnLoadGame();
            return;
        }

        if (m_SceneChangingManager.inBattle)
        {
            Debug.Log("Right");
            m_Player.LoadExitFromBattle();
        }
        else
        {
            m_Player.LoadOnSceneLoaded();
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_meetEnemy.CheckWalkedDistance();
    }
}
