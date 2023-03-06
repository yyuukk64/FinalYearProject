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

    /*
    public AudioSource BGM_Forest_Intro;
    public AudioSource BGM_Forest_Loop;
    public AudioSource BGM_Battle_Intro;
    public AudioSource BGM_Battle_Loop;
    */

    Vector3 oldPosition;
    //public Vector3 beforeBatPos;
    float wolkedDistance;

    PlayerManager PM;
    PlayerMovement PMove;
    BGMLoop bGMLoop;
    changeScene CS;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = _Player.transform.position;
        PM = FindObjectOfType<PlayerManager>();
        PMove = FindObjectOfType<PlayerMovement>();
        bGMLoop = FindObjectOfType<BGMLoop>();
        CS = FindObjectOfType<changeScene>();

        //make sure player can move
        PMove.canMove = true;

        //For animation [Enter Battle]
        anim = _enterBattle.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        wolkedDistance += Vector3.Distance(_Player.transform.position, oldPosition);
        oldPosition = _Player.transform.position;

        if(wolkedDistance > 20)
        {
            EnterBattle();
            wolkedDistance = 0;
        }
    }

    void EnterBattle()
    {
        float i = Random.Range(0.0f, 100f);
        Debug.Log("i is " + i);
        if (i > 60)
        {
            //Stop and Play 
            ForestBGM.SetActive(false);
            BattleBGM.SetActive(true);
            PMove.canMove = false;

            //Back to other scene is not allowed
            CS.canChange = false;

            anim.SetBool("isEnter", true);

            //beforeBatPos = _Player.transform.position;
            StartCoroutine(DelayEnterScene());
        }
    }

    IEnumerator DelayEnterScene()
    {
        //CS.savePositionBeforeBattle();
        yield return new WaitForSeconds(2);
        CS.ChangeScene("Battle_Forest");
    }
}
