using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleMNG : MonoBehaviour
{
    public GameObject _Player;
    [Header("The Enemy would be met in this area")]
    public GameObject[] _EnemyList;
    //[HideInInspector]
    public GameObject _Enemy;
    [SerializeField] GameObject _Soul;

    [HideInInspector] public bool isWin = false;
    bool Waiting = false;

    //For BGM
    public GameObject BattleBGM;
    private AudioSource BGMSource;

    //Winning Animation
    [SerializeField] GameObject winningCanvas;
    Animator anim;
    [HideInInspector] int getMoney;
    [SerializeField] TextMeshProUGUI txt_GetCoin;
    

    //show souls requirement number
    [SerializeField] TextMeshProUGUI txt_SoulReq;

    //Lost Animation
    public bool isLost = false;
    [SerializeField] TextMeshProUGUI txt_LostCoin;

    PlayerMovement PMove;
    PlayerManager PM;
    MeetEnemy ME;
    SceneChangingManager m_SceneChanging;

    // Start is called before the first frame update
    void Start()
    {
        PMove = FindObjectOfType<PlayerMovement>();
        PM = FindObjectOfType<PlayerManager>();
        m_SceneChanging = FindObjectOfType<SceneChangingManager>();

        //For Stop the BGM while winning
        BattleBGM = GameObject.FindWithTag("BattleBGM");
        BGMSource = BattleBGM.GetComponent<AudioSource>();
        
        //For Animetion
        anim = winningCanvas.GetComponent<Animator>();
        ME = winningCanvas.GetComponent<MeetEnemy>();

        //Make Sure Playercan move
        isLost = false;
        PMove.canMove = true;
        _Player.transform.position = new Vector3(0, 2.65f, 0);
        _Player.GetComponent<PlayerManager>().LoadOnEnterBattle();


        float j = Random.Range(0.0f, 100.0f);
        Debug.Log(j);
        if (j > 50)
        {
            Instantiate(_EnemyList[0]);
            _Enemy = _EnemyList[0];
        }
            
        else
        {
            Instantiate(_EnemyList[1]);
            _Enemy = _EnemyList[1];
        }

        //show souls requirement number
        txt_SoulReq.text = "Souls Requirement: " + _Enemy.GetComponent<GeneralEnemy>().SoulNumberReq.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWin && !Waiting && !isLost)
        {
            StartCoroutine(SpawnNewSoul());
        }

        if(_Player.GetComponent<PlayerManager>().health <= 0 && !isLost)
        {
            Lost();
        }
    }

    IEnumerator SpawnNewSoul()
    {
        Waiting = true;
        yield return new WaitForSeconds(5);

        var position = new Vector3(Random.Range(-40.0f, 40.0f), 2, Random.Range(-30.0f, 30.0f));
        Instantiate(_Soul, position, Quaternion.identity);

        Waiting = false;
    }

    [System.Obsolete]
    public void Win()
    {
        anim.SetBool("Win", true);
        PMove.canMove = false;

        //get Money
        getMoney = Random.RandomRange(_Enemy.GetComponent<GeneralEnemy>().MinMoney, _Enemy.GetComponent<GeneralEnemy>().MaxMoney);
        txt_GetCoin.text = getMoney.ToString();
        PM.coin += getMoney;

        //Stop Battle BGM
        BattleBGM.SetActive(false);
    }

    [System.Obsolete]
    public void Lost()
    {
        isLost = true;
        anim.SetBool("Lost", true);
        PMove.canMove = false;

        //Lost money
        getMoney = Random.RandomRange(_Enemy.GetComponent<GeneralEnemy>().MinMoney, _Enemy.GetComponent<GeneralEnemy>().MaxMoney);
        if (getMoney >= PM.coin)
            getMoney = PM.coin;
        txt_LostCoin.text = "-" + getMoney.ToString();
        PM.coin -= getMoney;
        
        BattleBGM.SetActive(false);
    }

    public void Back2Wild()
    {
        m_SceneChanging.LoadSceneExitFromBattle();
    }

    public void Back2Lobby()
    {
        m_SceneChanging.ChangeScene("Lobby");
    }
}
