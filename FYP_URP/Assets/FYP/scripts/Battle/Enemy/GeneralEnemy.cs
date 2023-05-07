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
    }

    public void Initially()
    {
        _Enemy.transform.position = _EnemyPos;
        for (int i = 0; i < _SoulPos.Count; i++)
        {
            m_soulPooling.callSoulSpawn(_SoulPos[i]);
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

}
