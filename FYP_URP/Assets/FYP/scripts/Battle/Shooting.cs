using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    SoulPooling m_soulPooling;

    [HideInInspector] public bool isShooted = false;

    public float speedSetoff = 100f;

    private void Start()
    {
        m_soulPooling = FindObjectOfType<SoulPooling>();
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
        if (other.tag == "Enemy" && isShooted)
        {
            this.gameObject.SetActive(false);
            isShooted = false;

            //hurt Enemy...


            return;
        }

        //if the shooted soul touch the barrier
        if (other.tag == "Boundary" && isShooted)
        {
            this.gameObject.SetActive(false);
            isShooted = false;
        }
    }

    public void resetSoul()
    {

    }
}
