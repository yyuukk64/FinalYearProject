using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Header("Menu Object")]
    [SerializeField] GameObject Title;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    [SerializeField] GameObject m_initialize;


    private void Start() 
    {
        
        //DisableButtonsDependingOnData();
    }

    public void OnBtnNewGameClicked()
    {
        m_initialize.GetComponent<Initialize>().Init();
        SceneManager.LoadScene("Lobby");
    }

    public void OnLoadGameClicked() 
    {
        m_initialize.GetComponent<Initialize>().Init();
        SceneChangingManager m_Scene;
        m_Scene = FindObjectOfType<SceneChangingManager>();

        m_Scene.Load = true;

        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log(data.currentScene);
        SceneManager.LoadScene(data.currentScene);
    }

    /*public void OnContinueGameClicked() 
    {
        DisableMenuButtons();
        // save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        // load the next scene - which will in turn load the game because of 
        // OnSceneLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("Lobby");
    }

    private void DisableMenuButtons() 
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
*/
    public void ActivateMenu() 
    {
        this.gameObject.SetActive(true);
        //DisableButtonsDependingOnData();
    }

    public void DeactivateMenu() 
    {
        this.gameObject.SetActive(false);
    }
}
