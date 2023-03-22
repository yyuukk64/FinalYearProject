using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject _Enemy;
    [SerializeField] GameObject _Soul; 
    [SerializeField] GameObject _Player; 
    [Space()]
    [Header("Initail Setting")]
    [SerializeField] Vector3 _EnemyPos;
    [SerializeField] List<Vector3> _SoulPos;
    [Space()]
    public int SoulNumberReq;
    [Space()]
    public int MinMoney;
    public int MaxMoney;

    BattleMNG BMNG;

    // Start is called before the first frame update
    void Start()
    {
        BMNG = FindObjectOfType<BattleMNG>();
        _Player = BMNG._Player;
        BMNG._Enemy = _Enemy;
        Initially();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && 
            _Player.GetComponent<TheQueue>()._Queue.Count - 1 >= SoulNumberReq)
        {
            BMNG.isWin = true;
            Debug.Log("You win!!!");
            //Do something...
            BMNG.Win();
        }
    }

    private void Initially()
    {
        _Enemy.transform.position = _EnemyPos;
        for (int i = 0; i < _SoulPos.Count; i++)
        {
            Instantiate(_Soul, _SoulPos[i], Quaternion.identity);
        }
        
    }
}
