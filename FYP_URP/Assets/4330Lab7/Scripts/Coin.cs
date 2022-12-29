using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private LevelManager levelManager;
    public int coinValue;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelManager.AddCoin(coinValue);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }     
    }
}
