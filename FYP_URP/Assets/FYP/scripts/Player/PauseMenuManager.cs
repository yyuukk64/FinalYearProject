using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuManager : MonoBehaviour
{
    PlayerManager m_Player;

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

    [SerializeField] GameObject QuitNotification;
    public void QuitGame()
    {
        QuitNotification.SetActive(true);
    }

    public void YesQuit()
    {
        InventoryUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void Setting()
    {
        Debug.Log("on progress");
    }

    [SerializeField] GameObject SuccessNotifacation;

    public void Save()
    {
        m_Player = FindObjectOfType<PlayerManager>();
        m_Player.SavePlayer();
        SuccessNotifacation.SetActive(true);
    }

    public void CloseNotifacation(GameObject Notification)
    {
        Notification.SetActive(false);
    }

    public void Inventory()
    {
        pauseMenuUI.SetActive(false);
        InventoryUI.SetActive(true);
    }
}

