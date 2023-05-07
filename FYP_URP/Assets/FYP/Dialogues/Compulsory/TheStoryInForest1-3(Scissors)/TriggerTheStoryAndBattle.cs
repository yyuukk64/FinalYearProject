using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTheStoryAndBattle : MonoBehaviour
{
    [Header("BGM")]
    public GameObject ForestBGM;
    public GameObject BattleBGM;

    [Header("Animation")]
    [SerializeField] GameObject _enterBattle;
    Animator anim;

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

        //For animation [Enter Battle]
        anim = _enterBattle.GetComponent<Animator>();

        if (m_Player.Passed_and_Get_Scissor)
        {
            Destroy(this.gameObject);
        }

        
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !m_Player.Passed_and_Get_Scissor)
        {
            //Animation (Fade Out)...

            //Make Player can't move

            //Make Player can't call Pause menu

            //Player the Dialogue...

            //Enter the Battle
            //Stop and Play 
            ForestBGM.SetActive(false);
            BattleBGM.SetActive(true);
            m_Movement.canMove = false;

            //Back to other scene is not allowed
            m_sceneChangingManager.canChange = false;

            anim.SetBool("isEnter", true);

            StartCoroutine(DelayEnterScene());
        }
    }

    IEnumerator DelayEnterScene()
    {
        yield return new WaitForSeconds(2);
        m_sceneChangingManager.EnterBattleScene("Battle_ForestBoss");
    }
}
