using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    SoulPooling m_soulPooling;
    Collect m_collect;
    BattleMNG m_battleMNG;
    

    [HideInInspector] public bool isShooted = false;

    public float speedSetoff = 100f;
    public GameObject Enemy;
    public GameObject Player;

    [SerializeField]
    AudioSource AttackedEnemySFX;

    private void Start()
    {
        m_soulPooling = FindObjectOfType<SoulPooling>();
        m_collect = FindObjectOfType<Collect>();
        m_battleMNG = FindObjectOfType<BattleMNG>();

        Enemy = GameObject.FindWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooted)
        {
            transform.Translate(Vector3.forward * speedSetoff * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            resetSoul();

            this.AttackedEnemySFX.Play();

            //hurt Enemy...
            Enemy.GetComponent<GeneralEnemy>().hurtEnemy(Player.GetComponent<PlayerManager>().attack);

            Debug.Log(Enemy.GetComponent<GeneralEnemy>().health + " / " + m_battleMNG.floatEnemyMaxHealth);
            m_battleMNG.imgEnemyHealth.GetComponent<Image>().fillAmount = (Enemy.GetComponent<GeneralEnemy>().health / m_battleMNG.floatEnemyMaxHealth);

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
