using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeAttacked : MonoBehaviour
{
    [SerializeField] GameObject BeAttackDetector;   //The Object which have Collider Component
    [SerializeField] GameObject ImpactEffect;
    [SerializeField] GameObject Player;
    [Space()]
    [SerializeField] int Damage;


    BattleMNG_Boss_GetScissor BMNG;
    PlayerManager PM;

    private void Start()
    {
        PM = FindObjectOfType<PlayerManager>();
        BMNG = FindObjectOfType<BattleMNG_Boss_GetScissor>();
        Player = BMNG._Player;
    }

    public void HurtPlayer(int takeDamage)
    {
        PM.health -= takeDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!BMNG.isWin && !BMNG.isLost)
            {
                HurtPlayer(this.Damage);

                // Attacked effect
                Instantiate(ImpactEffect, Player.transform.position + new Vector3(0f, 1.4f, 1.4f), Quaternion.identity);
            }
        }
        //Item.SetActive(false);
    }
}
