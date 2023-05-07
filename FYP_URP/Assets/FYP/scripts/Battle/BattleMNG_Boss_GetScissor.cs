using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleMNG_Boss_GetScissor : MonoBehaviour
{
    public GameObject _Player;

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
    public Image imgEnemyHealth;
    public float floatEnemyMaxHealth;
    public float floatEnemyHealth;

    //Lost Animation
    public bool isLost = false;
    [SerializeField] TextMeshProUGUI txt_LostCoin;

    PlayerMovement PMove;
    PlayerManager PM;
    MeetEnemy ME;
    SceneChangingManager m_SceneChanging;
    SoulPooling m_soulPooling;

    // Start is called before the first frame update
    void Start()
    {
        PMove = FindObjectOfType<PlayerMovement>();
        PM = FindObjectOfType<PlayerManager>();
        m_SceneChanging = FindObjectOfType<SceneChangingManager>();
        m_soulPooling = this.GetComponent<SoulPooling>();

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
        _Player.GetComponent<PlayerManager>().Init();
        _Player.GetComponent<PlayerManager>().LoadOnEnterBattle();

            Instantiate(_Enemy);

        //show souls requirement number
        floatEnemyMaxHealth = _Enemy.GetComponent<GeneralEnemy>().health;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWin && !Waiting && !isLost)
        {
            StartCoroutine(SpawnNewSoul());
        }

        if (_Player.GetComponent<PlayerManager>().health <= 0 && !isLost)
        {
            Lost();
        }
    }

    IEnumerator SpawnNewSoul()
    {
        Waiting = true;
        yield return new WaitForSeconds(5);

        var position = new Vector3(Random.Range(-40.0f, 40.0f), 2, Random.Range(-30.0f, 30.0f));

        m_soulPooling.callSoulSpawn(position);

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
        PM.AddMoney(getMoney);

        PM.Passed_and_Get_Scissor = true;

        //Stop Battle BGM
        Destroy(BattleBGM);
    }

    [System.Obsolete]
    public void Lost()
    {
        isLost = true;
        anim.SetBool("Lost", true);
        PMove.canMove = false;

        //Lost money
        getMoney = Random.RandomRange(90, 110);
        if (getMoney >= PM.coin)
            getMoney = PM.coin;
        txt_LostCoin.text = "-" + getMoney.ToString();
        PM.PayMoney(getMoney);

        m_SceneChanging.inBattle = false;

        Destroy(BattleBGM);
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
