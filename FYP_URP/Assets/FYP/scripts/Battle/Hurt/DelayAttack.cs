using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAttack : MonoBehaviour
{
    [SerializeField] float DelayTime;
    [SerializeField] GameObject AttackedDetector;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(DelayTime);
        AttackedDetector.SetActive(true);
        yield return new WaitForSeconds(DelayTime);
        AttackedDetector.SetActive(false);
    }
}
