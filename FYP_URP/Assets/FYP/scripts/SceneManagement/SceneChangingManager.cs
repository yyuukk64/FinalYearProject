using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangingManager : Singleton<SceneChangingManager>
{
    [SerializeField]private PlayerManager m_player;
    private TemporarilySave m_temp;
    private GameObject player;

    public bool canChange = false;
    public bool inBattle = false;

    public string SceneName;

    private void Start()
    {
        m_temp = FindObjectOfType<TemporarilySave>();
        m_player = FindObjectOfType<PlayerManager>();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (canChange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeScene(SceneName);
            }
        }
    }

    

    public void ChangeScene(string m_SceneName)
    {
        player = GameObject.FindWithTag("Player");
        m_player = player.GetComponent<PlayerManager>();
        m_player.SaveTemprarily();
        SceneManager.LoadScene(m_SceneName);
    }

    public void EnterBattleScene(string m_SceneName)
    {
        player = GameObject.FindWithTag("Player");
        m_player = player.GetComponent<PlayerManager>();
        SceneName = m_player.currentScene;
        m_player.SaveTemprarily();
        SceneManager.LoadScene(m_SceneName);
    }

    public void LoadSceneExitFromBattle()
    {
        player = GameObject.FindWithTag("Player");
        m_player = player.GetComponent<PlayerManager>();
        m_player.SaveTemprarily();
        SceneManager.LoadScene(SceneName);
    }
}
