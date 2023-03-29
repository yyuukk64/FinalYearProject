using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMLoop : MonoBehaviour
{
    [SerializeField] float introLengthSec;
    [SerializeField] AudioSource Intro;
    [SerializeField] AudioSource Loop;

    public bool beContinue = true;

    // Start is called before the first frame update
    void Start()
    {
        beContinue = true;
        StartCoroutine(PlayerLoop());
    }

    IEnumerator PlayerLoop()
    {
        yield return new WaitForSeconds(introLengthSec);
        if (beContinue)
        {
            Loop.Play();
        }
    }
}
