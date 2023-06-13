using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingBoss : MonoBehaviour
{
    SoulPooling m_soulPooling;
    Collect m_collect;
    BattleMNG_Boss_GetScissor m_battleMNG;
    BossScissor m_Boss;
    PlayerManager m_Player;


    public bool isShooted = false;

    public float speedSetoff = 100f;
    public GameObject Enemy;
    public GameObject Player;

    public GameObject Impact;

    [SerializeField]
    AudioSource AttackedEnemySFX;

    public float ResetTime = 30.0f;

    private void Start()
    {
        m_soulPooling = FindObjectOfType<SoulPooling>();
        m_collect = FindObjectOfType<Collect>();
        m_battleMNG = FindObjectOfType<BattleMNG_Boss_GetScissor>();
        m_Boss = FindObjectOfType<BossScissor>();
        m_Player = FindObjectOfType<PlayerManager>();

        Enemy = GameObject.FindWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooted)
        {
            transform.Translate(Vector3.forward * speedSetoff * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            resetSoul();
            Instantiate(Impact, this.gameObject.transform.position, Quaternion.identity);

            this.AttackedEnemySFX.Play();

            //hurt Enemy...
            m_Boss.hurtEnemy(m_Player.attack);

            Debug.Log(m_Boss.health + " / " + m_battleMNG.floatEnemyMaxHealth);
            m_battleMNG.imgEnemyHealth.GetComponent<Image>().fillAmount = (m_Boss.health / m_battleMNG.floatEnemyMaxHealth);

            return;
        }

        //if the shooted soul touch the barrier
        if (other.tag == "Boundary")
        {
            resetSoul();
            return;
        }
    }

    public void resetSoul()
    {
        this.gameObject.SetActive(false);
        this.GetComponent<Collect>().canCollect = true;
        isShooted = false;
    }
}
