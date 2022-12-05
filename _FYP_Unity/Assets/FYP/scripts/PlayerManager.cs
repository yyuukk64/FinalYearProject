using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, heart4, heart5, heart6, heart7, heart8, heart9, heart10;
   

    [SerializeField] int health = 6, maxHealth = 6;
    private int OldMaxHealth;
    public Sprite heartFull, heartHalf, heartEmpty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMaxHealth(int MaxHealthToAdd)
    {
        maxHealth += MaxHealthToAdd;
        health = maxHealth;     //fully recover

        if (maxHealth >= 8)
        {
            heart4.SetActive(true);
        }
        if (maxHealth >= 10)
        {
            heart5.SetActive(true);
        }
        if (maxHealth >= 12)
        {
            heart6.SetActive(true);
        }
        if (maxHealth >= 14)
        {
            heart7.SetActive(true);
        }
        if (maxHealth >= 16)
        {
            heart8.SetActive(true);
        }
        if (maxHealth >= 18)
        {
            heart9.SetActive(true);
        }
        if (maxHealth >= 20)
        {
            heart10.SetActive(true);
        }
    }
}
