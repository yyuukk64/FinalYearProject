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
    public Transform PositionBeforeEnterBattle;
    public float x, y, z;

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
    /*
    public void save()
    {
        PlayerPrefs.SetInt("CurrentHealth", Player.GetComponent<PlayerManager>().health);
        PlayerPrefs.SetInt("CurrentMoney", Player.GetComponent<PlayerManager>().Money);
        PlayerPrefs.SetInt("CurrentMaxHealth", Player.GetComponent<PlayerManager>().MaxHealth);
    }

    public void load()
    {
        Player.GetComponent<PlayerManager>().health = PlayerPrefs.GetInt("CurrentHealth", 6);
        Player.GetComponent<PlayerManager>().Money = PlayerPrefs.GetInt("CurrentMoney", 0);
        Player.GetComponent<PlayerManager>().MaxHealth = PlayerPrefs.GetInt("CurrentMaxHealth", 6);
    }
    public void savePositionBeforeBattle()
    {
        PlayerPrefs.SetFloat("XPositionBeforeBattle", Player.transform.position.x);
        PlayerPrefs.SetFloat("YPositionBeforeBattle", Player.transform.position.y);
        PlayerPrefs.SetFloat("ZPositionBeforeBattle", Player.transform.position.z);
    }

    public void loadPositionAfterBattle()
    {
        x = PlayerPrefs.GetFloat("XPositionBeforeBattle", 0f);
        y = PlayerPrefs.GetFloat("YPositionBeforeBattle", 0f);
        z = PlayerPrefs.GetFloat("ZPositionBeforeBattle", 0f);
        PositionBeforeEnterBattle.position = new Vector3(x, y, z);
    }
    */
    

    public void ChangeScene(string m_SceneName)
    {
        //save();
        SceneManager.LoadScene(m_SceneName);
    }
}
