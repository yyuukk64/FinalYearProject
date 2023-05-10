using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject BeginningStory;

    SceneChangingManager m_SceneChangingManager;

    // Start is called before the first frame update
    void Start()
    {
        //Init
        m_SceneChangingManager = FindObjectOfType<SceneChangingManager>();


        _Player = GameObject.FindWithTag("Player");
        _Player.GetComponent<PlayerManager>().Init();
        _Player.GetComponent<PlayerManager>().LoadOnSceneLoaded();
        _Player.transform.position = new Vector3(0f, 1.53f, -70f);
        _Player.GetComponent<PlayerManager>().health = _Player.GetComponent<PlayerManager>().maxHealth;

        if (m_SceneChangingManager.Load)
        {
            _Player.GetComponent<PlayerManager>().LoadOnLoadGame();
            if (_Player.GetComponent<PlayerManager>().FirstIn)
            {
                Instantiate(BeginningStory);
            }
        }
    }
}
