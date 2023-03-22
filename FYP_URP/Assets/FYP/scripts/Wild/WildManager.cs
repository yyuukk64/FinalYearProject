using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildManager : MonoBehaviour
{
    MeetEnemy m_meetEnemy;
    SceneChangingManager m_SceneChangingManager;

    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        m_meetEnemy = this.GetComponent<MeetEnemy>();
        m_SceneChangingManager = FindObjectOfType<SceneChangingManager>();
        _player = GameObject.FindWithTag("Player");
        _player.GetComponent<PlayerManager>().Init();

        //load Temporarily data
        if(m_SceneChangingManager.inBattle)
        {
            _player.GetComponent<PlayerManager>().LoadExitFromBattle();
        }
        else
        {
            _player.GetComponent<PlayerManager>().LoadOnSceneLoaded();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        m_meetEnemy.CheckWalkedDistance();
    }
}
