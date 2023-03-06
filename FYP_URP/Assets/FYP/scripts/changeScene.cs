using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField] GameObject EBtn_Canvas;
    public bool canChange = false;
    [SerializeField] string SceneName;
    [SerializeField] GameObject Player;

    private void Update()
    {
        if (canChange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                save();
                SceneManager.LoadScene(SceneName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EBtn_Canvas.SetActive(true);
            canChange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EBtn_Canvas.SetActive(false);
            canChange = false;
        }
    }

    public void save()
    {
        PlayerPrefs.SetInt("CurrentHealth", Player.GetComponent<PlayerManager>().health);
        PlayerPrefs.SetInt("CurrentMoney", Player.GetComponent<PlayerManager>().Money);
        PlayerPrefs.SetInt("CurrentMaxHealth", Player.GetComponent<PlayerManager>().MaxHealth);
    }

    public void load()
    {
        Player.GetComponent<PlayerManager>().health = PlayerPrefs.GetInt("CurrentHealth");
        Player.GetComponent<PlayerManager>().Money = PlayerPrefs.GetInt("CurrentMoney");
        Player.GetComponent<PlayerManager>().MaxHealth = PlayerPrefs.GetInt("CurrentMaxHealth");
    }
}
