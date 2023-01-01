using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject[] heart = new GameObject[10];
    [SerializeField] Image[] heartState = new Image[10];

    public int health = 6, maxHealth = 6;
    public Sprite heartFull, heartHalf, heartEmpty;

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
        if (health == 0)
        {
            for (int i = 0; i <10 ; i++)
            {
                heartState[i].sprite = heartEmpty;
            }
        }
    }
}
