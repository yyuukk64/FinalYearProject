using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    [SerializeField] GameObject TemporarilySaveObject;
    [SerializeField] GameObject SceneChengingManager;

    public void Init()
    {
        Instantiate(TemporarilySaveObject);
        Instantiate(SceneChengingManager);
    }
}
