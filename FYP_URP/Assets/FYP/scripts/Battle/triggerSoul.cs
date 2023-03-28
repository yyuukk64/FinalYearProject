using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSoul : MonoBehaviour
{
    SoulPooling m_soulPooling;

    protected void Start()
    {
        m_soulPooling = FindObjectOfType<SoulPooling>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        /*
        for (int i = 0; i < m_soulPooling.quanLimited; i++)
        {
            Debug.Log("soul_" + i);
            if(other.tag == "soul_" + i)
            {
                other.GetComponent<Shooting>().resetSoul();
                return;
            }
            else
            {
                return;
            }
        }


        */


        if(other.tag == "soul_0")
        {
            other.GetComponent<Shooting>().resetSoul();
            return;
        }
    }               


}
