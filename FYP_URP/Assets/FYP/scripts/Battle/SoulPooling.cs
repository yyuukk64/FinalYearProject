using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPooling : MonoBehaviour
{
    public static SoulPooling SharedInstance;
    public int quanLimited = 10;
    private GameObject[] allSoul;

    [Header("Assign GameObject")]
    public Transform spawnPoint;
    public Transform parent;
    public GameObject instanceSoul;

    private void Awake()
    {
        SharedInstance = this;

        allSoul = new GameObject[quanLimited];

        for (int i = 0; i < quanLimited; i++)
        {
            GameObject soul = Instantiate(instanceSoul) as GameObject;
            soul.SetActive(false);
            soul.transform.SetParent(parent);
            soul.transform.position = Vector3.zero;
            allSoul[i] = soul;
        }
    }

    public void callSoulSpawn(Vector3 position)
    {
        GameObject soul = SoulPooling.SharedInstance.GetPooledSoul();
        soul.transform.position = position;
        soul.transform.rotation = spawnPoint.rotation;
        soul.SetActive(true);
    }

    public GameObject GetPooledSoul()
    {
        for (int i = 0; i < allSoul.Length; i++)
        {
            if(!allSoul[i].activeInHierarchy)
            {
                return allSoul[i];
            }
        }
        return null;
    }
}
