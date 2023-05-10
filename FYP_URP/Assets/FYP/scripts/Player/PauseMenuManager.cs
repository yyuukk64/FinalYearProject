using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenuManager : MonoBehaviour
{
    PlayerManager m_Player;
    SceneChangingManager m_Scene;

    public static bool GameIsPaused = false;
    public bool CanPause = true;

    public GameObject pauseMenuUI;
    public GameObject InventoryUI;

    public Button btn_Save;
    public Button btn_BarcodeReader;


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
        m_Scene = FindObjectOfType<SceneChangingManager>();
        m_Player = FindObjectOfType<PlayerManager>();

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        if (m_Player.canScan)
        {
            btn_BarcodeReader.interactable = true;
        }
        else
        {
            btn_BarcodeReader.interactable = false;
        }

        if (m_Scene.inBattle)
        {
            btn_Save.interactable = false;
            btn_BarcodeReader.interactable = false;
        }
        else
        {
            btn_Save.interactable = true;
        }
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

        GameObject TemporarilySaveObject = GameObject.Find("TemporarilySaveObject(Clone)");
        GameObject SceneChengingManager = GameObject.Find("SceneChengingManager(Clone)");

        Destroy(TemporarilySaveObject);
        Destroy(SceneChengingManager);

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

    public GameObject barcodeReader;

    public void openBarcodeReader()
    {
        pauseMenuUI.SetActive(false);
        barcodeReader.SetActive(true);
    }

    public void closeBarcodeReader()
    {
        barcodeReader.SetActive(false);
        pauseMenuUI.SetActive(true);
        Debug.Log("Closed!");
    }
}

