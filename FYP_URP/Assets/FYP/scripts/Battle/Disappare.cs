using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappare : MonoBehaviour
{
    float Daley_Time = 7f;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        StartCoroutine(DaleyToDisappare());
    }

    IEnumerator DaleyToDisappare()
    {
        yield return new WaitForSeconds(Daley_Time);

        anim.SetTrigger("End");
        yield return new WaitForSeconds(4);

        Destroy(this.gameObject);
    }
}
