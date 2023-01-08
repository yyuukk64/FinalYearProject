using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleMNG : MonoBehaviour
{


    public GameObject _Player;
    [HideInInspector] public GameObject _Enemy;
    [SerializeField] GameObject _Soul;

    [HideInInspector] public bool isWin = false;
    bool Waiting = false;

    //Winning Animation
    [SerializeField] GameObject winningCanvas;
    Animator anim;
    [HideInInspector] int getMoney;
    [SerializeField] TextMeshProUGUI txt_Coin;

    PlayerMovement PMove;
    PlayerManager PM;

    // Start is called before the first frame update
    void Start()
    {
        PMove = FindObjectOfType<PlayerMovement>();
        PM = FindObjectOfType<PlayerManager>();
        anim = winningCanvas.GetComponent<Animator>();
        PMove.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWin && !Waiting)
        {
            StartCoroutine(SpawnNewSoul());
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

    public void Win()
    {
        anim.SetBool("Win", true);
        PMove.canMove = false;
        getMoney = Random.RandomRange(_Enemy.GetComponent<GeneralEnemy>().MinMoney, _Enemy.GetComponent<GeneralEnemy>().MaxMoney);
        txt_Coin.text = getMoney.ToString();
        PM.Money += getMoney;
    }
}
