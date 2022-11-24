using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int health, maxHealth = 6;
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

    void AddMaxHealth()
    {
        OldMaxHealth = maxHealth;
        maxHealth += 2;
        health = maxHealth;     //fully recover

    }
}
