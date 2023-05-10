using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : Singleton<PlayerManager>
{
    [Header("Assign UI Object")]
    [SerializeField] public GameObject EBtnCanvas;
    [SerializeField] GameObject[] heart = new GameObject[10];
    [SerializeField] Image[] heartState = new Image[10];

    [Header("Player Data")]
    public int coin = 0;
    [SerializeField] TextMeshProUGUI txtCoin;

    public int health, maxHealth = 6;
    public int attack = 1;

    public bool canScan = true;
    public int ScanCD = 3600;

    public Sprite heartFull, heartHalf, heartEmpty;

    public string currentScene;
    public int[] Consumables = new int[7];

    [Header("process")]
    public bool EnteredForest1_1 = false;
    public bool EnteredForest1_4 = false;
    public bool Passed_and_Get_Scissor = false;

    //public bool showEBtnCanvas = false;
    
    [SerializeField] TemporarilySave m_temporarilySave;
    SceneChangingManager m_Scene;

    #region Real Save
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(data.position[i]);
        }

        health = data.health;
        maxHealth = data.maxHealth;
        attack = data.attack;
        coin = data.coin;

        for (int i = 0; i < 7; i++)
        {
            Consumables[i] = data.Consumables[i];
            Debug.Log(Consumables[i]);
        }

        ScanCD = data.ScanCD;


        //Location
        currentScene = data.currentScene;
        //changingScene
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    #endregion

    #region Temporarily Save

    public void SaveTemprarily()
    {
        m_temporarilySave = FindObjectOfType<TemporarilySave>();
        m_temporarilySave.TemporarilyData(this);
    }

    public void SaveBeforeBattle()
    {
        SaveTemprarily();
        m_temporarilySave.posBeforeBattle = this.transform.position;
    }
    public void LoadOnEnterBattle()
    {
        this.health = m_temporarilySave.health;
        this.maxHealth = m_temporarilySave.maxHealth;
        this.coin = m_temporarilySave.coin;
        this.attack = m_temporarilySave.attack;
        this.ScanCD = m_temporarilySave.ScanCD;

        for (int i = 0; i < 7; i++)
        {
            Consumables[i] = m_temporarilySave.Consumables[i];
        }
    }

    public void LoadOnSceneLoaded()
    {
        LoadOnEnterBattle();

        this.transform.position = m_temporarilySave.posForGate;
    }

    public void LoadExitFromBattle()
    {
        LoadOnEnterBattle();
        m_Scene.inBattle = false;
        this.transform.position = new Vector3(m_temporarilySave.posBeforeBattle[0], m_temporarilySave.posBeforeBattle[1], m_temporarilySave.posBeforeBattle[2]);
    }

    public void LoadOnLoadGame()
    {
        if (m_Scene.Load)
        {
            LoadPlayer();
            m_Scene.Load = false;
            SaveBeforeBattle();
        }
    }

    #endregion

    public void activeEBtnCanvas(bool showEBtnCanvas)
    {
        if (showEBtnCanvas)
        {
            EBtnCanvas.SetActive(true);
        }
        else
        {
            EBtnCanvas.SetActive(false);
        }
    }

    // Start is called before the first frame update
    public void Init()
    {
        m_temporarilySave = FindObjectOfType<TemporarilySave>();
        m_Scene = FindObjectOfType<SceneChangingManager>();

        currentScene = SceneManager.GetActiveScene().name;
        for (int i = 0; i<3; i++)
        {
            heart[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        ShowHeart();
        ShowHealth();
        txtCoin.text = coin.ToString();

        if (canScan)
        {
            return;
        }
        ScanCD -= 1;
        if (ScanCD <= 0)
        {
            canScan = true;
        }
    }

    public void cannotScan()
    {

        canScan = false;
        ScanCD = 3600;
    }

    public void AddMaxHealth(int MaxHealthToAdd)
    {
        maxHealth += MaxHealthToAdd;
        health = maxHealth;     //fully recover        
    }
    void ShowHeart()
    {
        if (maxHealth >= 8)
        {
            heart[3].SetActive(true);
        }
        if (maxHealth >= 10)
        {
            heart[4].SetActive(true);
        }
        if (maxHealth >= 12)
        {
            heart[5].SetActive(true);
        }
        if (maxHealth >= 14)
        {
            heart[6].SetActive(true);
        }
        if (maxHealth >= 16)
        {
            heart[7].SetActive(true);
        }
        if (maxHealth >= 18)
        {
            heart[8].SetActive(true);
        }
        if (maxHealth >= 20)
        {
            heart[9].SetActive(true);
        }
    }

    void ShowHealth()
    {
        if(health == 20)
        {
            for (int i = 0; i < 10 ; i++)
            {
                heartState[i].sprite = heartFull;
            }
        }
        if (health == 19)
        {
            for (int i = 0; i < 9; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[9].sprite = heartHalf;
        }
        if (health == 18)
        {
            for (int i = 0; i < 9; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 8; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 17)
        {
            for (int i = 0; i < 8; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[8].sprite = heartHalf;
            for (int i = 9; i > 8; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 16)
        {
            for (int i = 0; i < 8; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 7; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 15)
        {
            for (int i = 0; i < 7; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[7].sprite = heartHalf;
            for (int i = 9; i > 7; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 14)
        {
            for (int i = 0; i < 7; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 6; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 13)
        {
            for (int i = 0; i < 6; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[6].sprite = heartHalf;
            for (int i = 9; i > 6; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 12)
        {
            for (int i = 0; i < 6; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 5; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 11)
        {
            for (int i = 0; i < 5; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[5].sprite = heartHalf;
            for (int i = 9; i > 5; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 10)
        {
            for (int i = 0; i < 5; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 4; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 9)
        {
            for (int i = 0; i < 4; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[4].sprite = heartHalf;
            for (int i = 9; i > 4; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 8)
        {
            for (int i = 0; i < 4; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 3; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 7)
        {
            for (int i = 0; i < 3; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[3].sprite = heartHalf;
            for (int i = 9; i > 3; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 6)
        {
            for (int i = 0; i < 3; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 2; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 5)
        {
            for (int i = 0; i < 2; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[2].sprite = heartHalf;
            for (int i = 9; i > 2; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 4)
        {
            for (int i = 0; i < 2; i++)
            {
                heartState[i].sprite = heartFull;
            }
            for (int i = 9; i > 1; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 3)
        {
            for (int i = 0; i < 1; i++)
            {
                heartState[i].sprite = heartFull;
            }
            heartState[1].sprite = heartHalf;
            for (int i = 9; i > 1; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 2)
        {
            heartState[0].sprite = heartFull;
            for (int i = 9; i > 0; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health == 1)
        {
            heartState[0].sprite = heartHalf;
            for (int i = 9; i > 0; i--)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
        if (health <= 0)
        {
            for (int i = 0; i <10 ; i++)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
    }

    public void AddMoney(int getMoney)
    {
        coin += getMoney;
    }

    public void PayMoney(int payMoney)
    {
        coin -= payMoney;
    }
}
