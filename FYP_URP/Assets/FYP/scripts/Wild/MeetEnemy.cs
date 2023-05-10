using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeetEnemy : MonoBehaviour
{
    public GameObject _Player;

    public GameObject ForestBGM;
    public GameObject BattleBGM;

    [SerializeField] GameObject _enterBattle;
    Animator anim;

    Vector3 oldPosition;
    //public Vector3 beforeBatPos;
    float walkedDistance;

    PlayerManager PM;
    PlayerMovement PMove;
    BGMLoop bGMLoop;
    SceneChangingManager m_sceneChangingManager;
    TemporarilySave m_temporarilySave;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = _Player.transform.position;
        PM = FindObjectOfType<PlayerManager>();
        PMove = FindObjectOfType<PlayerMovement>();
        bGMLoop = FindObjectOfType<BGMLoop>();
        m_sceneChangingManager = FindObjectOfType<SceneChangingManager>();
        m_temporarilySave = FindObjectOfType<TemporarilySave>();

        //make sure player can move
        PMove.canMove = true;

        //For animation [Enter Battle]
        anim = _enterBattle.GetComponent<Animator>();

        walkedDistance = 0;
    }

    // Update is called once per frame
    public void CheckWalkedDistance()
    {
        walkedDistance += Vector3.Distance(_Player.transform.position, oldPosition);
        oldPosition = _Player.transform.position;

        if(walkedDistance > 40)
        {
            walkedDistance = 0;
            EnterBattle();
        }
    }

    void EnterBattle()
    {
        //Randomize a number to decide that is it enter to battle.
        float i = Random.Range(0.0f, 100f);
        Debug.Log("i is " + i);
        if (i > 70)
        {
            //Stop and Play 
            ForestBGM.SetActive(false);
            BattleBGM.SetActive(true);
            PMove.canMove = false;

            //Back to other scene is not allowed
            m_sceneChangingManager.canChange = false;

            anim.SetBool("isEnter", true);

            StartCoroutine(DelayEnterScene());
        }
    }

    IEnumerator DelayEnterScene()
    {
        //CS.savePositionBeforeBattle();
        yield return new WaitForSeconds(2);
        m_sceneChangingManager.EnterBattleScene("Battle_Forest");
    }
}
