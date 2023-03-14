using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangingManager : Singleton<SceneChangingManager>
{
    
    public bool canChange = false;
    public bool inBattle = false;

    public string SceneName;

    private void Start()
    {
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
        //save();
        SceneManager.LoadScene(m_SceneName);
    }
}
