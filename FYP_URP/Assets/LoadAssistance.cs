using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssistance : MonoBehaviour
{
    public bool Load = true;

    // Start is called before the first frame update
    void Start()
    {
        Load = true;
        DontDestroyOnLoad(this);
    }
}
