using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.ResetPlayerData();

        SceneManager.LoadScene(0);
    }
}
