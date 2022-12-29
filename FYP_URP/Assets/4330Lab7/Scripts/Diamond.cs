using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private LevelManager levelManager;
    public int diamondValue;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelManager.AddDiamond(diamondValue);
            //Destroy(gameObject);
            gameObject.SetActive(false); 
        }
    }
}
