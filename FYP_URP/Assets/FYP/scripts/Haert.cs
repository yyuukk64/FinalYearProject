using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haert : MonoBehaviour
{
    private PlayerManager playerManager;
    public int HeartValue;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerManager.AddMaxHealth(HeartValue);
            gameObject.SetActive(false);
        }
    }
}
