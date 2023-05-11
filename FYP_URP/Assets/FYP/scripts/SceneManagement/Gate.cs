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
    private SceneChangingManager m_sceneManager;
    private TemporarilySave m_temporarilySave;


    void Start()
    {
        m_sceneManager = FindObjectOfType<SceneChangingManager>();
        m_temporarilySave = FindObjectOfType<TemporarilySave>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_sceneManager = FindObjectOfType<SceneChangingManager>();
            m_temporarilySave = FindObjectOfType<TemporarilySave>();

            m_Player = FindObjectOfType<PlayerManager>();
            m_Player.activeEBtnCanvas(true);
            m_sceneManager.canChange = true;
            m_sceneManager.SceneName = SceneName;

            m_temporarilySave.posForGate[0] = EntryPos.x;
            m_temporarilySave.posForGate[1] = EntryPos.y;
            m_temporarilySave.posForGate[2] = EntryPos.z;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_sceneManager = FindObjectOfType<SceneChangingManager>();
            m_temporarilySave = FindObjectOfType<TemporarilySave>();

            m_Player = FindObjectOfType<PlayerManager>();
            m_Player.activeEBtnCanvas(false);
            m_sceneManager.canChange = false;
            m_sceneManager.SceneName = null;
        }
    }
}
