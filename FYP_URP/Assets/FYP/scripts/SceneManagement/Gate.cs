using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{ 
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EBtn_Canvas;

    public string SceneName;
    public Vector3 EntryPos;

    private SceneChangingManager m_sceneManager;
    private TemporarilySave m_temporarilySave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EBtn_Canvas.SetActive(true);
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
            EBtn_Canvas.SetActive(false);
            m_sceneManager.canChange = false;
            m_sceneManager.SceneName = null;
        }
    }
}
