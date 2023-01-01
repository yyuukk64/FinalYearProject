using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTesting : MonoBehaviour
{
    [SerializeField] GameObject Item;
    [SerializeField] int hurt;

    PlayerManager PM;
    private void Start()
    {
        PM = FindObjectOfType<PlayerManager>();
    }

    public void HurtPlayer(int takeDamage)
    {
        PM.health -= takeDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HurtPlayer(Item.GetComponent<HurtTesting>().hurt);
        }
        Item.SetActive(false);
    }


}
