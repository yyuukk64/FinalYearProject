using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTheStoryAndBattle : MonoBehaviour
{
    [Header("BGM")]
    public GameObject ForestBGM;
    public GameObject BattleBGM;

    [Header("Animation")]
    [SerializeField] GameObject StoyrObject;
    [SerializeField] GameObject _enterBattle;
    Animator anim;

    [SerializeField] GameObject Forest1_3Block;

    //Script
    PlayerManager m_Player;
    PlayerMovement m_Movement;
    BGMLoop bGMLoop;
    SceneChangingManager m_sceneChangingManager;
    TemporarilySave m_temporarilySave;

    private void Awake()
    {
        m_Player = FindObjectOfType<PlayerManager>();
        m_Movement = FindObjectOfType<PlayerMovement>();
        m_sceneChangingManager = FindObjectOfType<SceneChangingManager>();
        m_temporarilySave = FindObjectOfType<TemporarilySave>();
        bGMLoop = FindObjectOfType<BGMLoop>();

        //For animation [Enter Battle]
        anim = _enterBattle.GetComponent<Animator>();

        if (m_Player.EnteredForest1_4)
        {
            Forest1_3Block.SetActive(false);
        }

        if (m_temporarilySave.WinTheFirstBoss)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !m_Player.WinTheFirstBoss)
        {
            Instantiate(StoyrObject);
        }
    }

    public void EnterBossBattle()
    {
        //Enter the Battle
        Destroy(GameObject.Find("BeforeScissorBoss"));
        //Stop and Play 
        ForestBGM.SetActive(false);
        BattleBGM.SetActive(true);
        m_Movement.canMove = false;

        //Back to other scene is not allowed
        m_sceneChangingManager.canChange = false;

        anim.SetBool("isEnter", true);

        StartCoroutine(DelayEnterScene());
    }

    IEnumerator DelayEnterScene()
    {
        yield return new WaitForSeconds(2);
        m_sceneChangingManager.EnterBattleScene("Battle_ForestBoss");
    }
}
