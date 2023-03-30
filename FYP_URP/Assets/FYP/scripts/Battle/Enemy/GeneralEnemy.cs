using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject _Enemy;
    [SerializeField] GameObject _Player; 

    [Space()]

    [Header("Initail Setting")]
    [SerializeField] Vector3 _EnemyPos;
    [SerializeField] List<Vector3> _SoulPos;

    [Space()]

    public int health;

    [Space()]

    public int MinMoney;
    public int MaxMoney;

    BattleMNG BMNG;
    SoulPooling m_soulPooling;

    // Start is called before the first frame update
    void Start()
    {
        BMNG = FindObjectOfType<BattleMNG>();
        _Player = BMNG._Player;
        BMNG._Enemy = _Enemy;
        m_soulPooling = FindObjectOfType<SoulPooling>();
        Initially();
    }

    private void Initially()
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
