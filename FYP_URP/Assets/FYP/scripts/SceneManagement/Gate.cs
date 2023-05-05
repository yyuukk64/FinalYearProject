using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{ 
    //[SerializeField] GameObject Player;

    //Which Scene will be enter by player
    public string SceneName;

    //Where is the spawn position in the next scene
    public Vector3 EntryPos;

    private PlayerManager m_Player;
    private GameObject player;
    private SceneChangingManager m_sceneManager;


    void Start()
    {
        m_sceneManager = FindObjectOfType<SceneChangingManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_sceneManager = FindObjectOfType<SceneChangingManager>();

            player = GameObject.FindWithTag("Player");
            m_Player = player.GetComponent<PlayerManager>();
            m_Player.activeEBtnCanvas(true);
            m_sceneManager.canChange = true;
            m_sceneManager.SceneName = SceneName;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_sceneManager = FindObjectOfType<SceneChangingManager>();


            player = GameObject.FindWithTag("Player");
            m_Player = player.GetComponent<PlayerManager>();
            m_Player.activeEBtnCanvas(false);
            m_sceneManager.canChange = false;
            m_sceneManager.SceneName = null;
        }
    }
}
