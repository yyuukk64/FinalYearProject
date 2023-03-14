using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour //, IDataPersistence
{
    [SerializeField] GameObject[] heart = new GameObject[10];
    [SerializeField] Image[] heartState = new Image[10];

    public int coin = 0;
    [SerializeField] TextMeshProUGUI txtCoin;

    public int health, maxHealth = 6;
    public Sprite heartFull, heartHalf, heartEmpty;

    public string currentScene;

    TemporarilySave m_temporarilySave;

    #region Real Save
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        maxHealth = data.maxHealth;
        coin = data.coin;

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

    public void SaveTemprarily(PlayerManager player)
    {
        m_temporarilySave = new TemporarilySave(this);
    }

    public void LoadOnSceneLoaded()
    {
        LoadOnEnterBattle();

        this.transform.position = new Vector3(m_temporarilySave.posForGate[0], m_temporarilySave.posForGate[1], m_temporarilySave.posForGate[2]);
    }

    public void LoadOnEnterBattle()
    {
        this.health = m_temporarilySave.health;
        this.maxHealth = m_temporarilySave.maxHealth;
        this.coin = m_temporarilySave.coin;
    }

    public void LoadExitFromBattle()
    {
        LoadOnEnterBattle(); 

        this.transform.position = new Vector3(m_temporarilySave.posBeforeBattle[0], m_temporarilySave.posBeforeBattle[1], m_temporarilySave.posBeforeBattle[2]);
    }

    public void LoadOnLoadGame()
    {

    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<3; i++)
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
}
