using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject _Enemy;
    public GameObject _Player; 

    [Space()]

    [Header("Initail Setting")]
    public Vector3 _EnemyPos;
    public List<Vector3> _SoulPos;

    [Space()]

    public int health;

    [Space()]

    public int MinMoney;
    public int MaxMoney;

    [Header("Enemy Movement")]
    private Rigidbody myRigidbody;

    public bool isWalking;

    public float StopTime;
    public float StopCD;
    public float MoveTime;
    public float MoveCD = 3;

    [SerializeField]
    protected int Speed = 10;

    private int WalkDirection;


    BattleMNG BMNG;
     protected  SoulPooling m_soulPooling;

    // Start is called before the first frame update
    void Start()
    {
        BMNG = FindObjectOfType<BattleMNG>();
        _Player = BMNG._Player;
        BMNG._Enemy = _Enemy;
        m_soulPooling = FindObjectOfType<SoulPooling>();
        Initially();

        myRigidbody = GetComponent<Rigidbody>();

        StopCD = StopTime;
        MoveCD = MoveTime;

        ChooseDirection();
    }

    public void Initially()
    {
        _Enemy.transform.position = _EnemyPos;
        for (int i = 0; i < _SoulPos.Count; i++)
        {
            m_soulPooling.callSoulSpawn(_SoulPos[i]);
        }
    }

    public void Update()
    {
        if (isWalking)
        {
            MoveCD -= Time.deltaTime;

            if (MoveCD < 0)
            {
                isWalking = false;
                StopCD = StopTime;
            }

            switch (WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector3(0, 0, Speed);
                    break;
                case 1:
                    myRigidbody.velocity = new Vector3(Speed, 0, 0);
                    break;
                case 2:
                    myRigidbody.velocity = new Vector3(0, 0, -Speed);
                    break;
                case 3:
                    myRigidbody.velocity = new Vector3(-Speed, 0, 0);
                    break;
                default:
                    myRigidbody.velocity = new Vector3(0, 0, Speed);
                    break;
            }
        }
        else
        {
            StopCD -= Time.deltaTime;

            myRigidbody.velocity = Vector3.zero;

            if (StopCD < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void hurtEnemy(int damage)
    {
        this.health -= damage;
        if (health <= 0)
        {
            BMNG.isWin = true;
            Debug.Log("You win!!!");
            //Do something...
            BMNG.Win();
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        MoveCD = MoveTime;
    }
}
