using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenuManager : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public bool CanPause = true;

    public GameObject pauseMenuUI;
    public GameObject InventoryUI;


    void Update()
    {
        if (!CanPause)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()

    {
        InventoryUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("on progress");
    }

    public void Setting()
    {
        Debug.Log("on progress");
    }

    public void Save()
    {
        Debug.Log("on progress");
    }

    public void Inventory()
    {
        pauseMenuUI.SetActive(false);
        InventoryUI.SetActive(true);
    }
}

