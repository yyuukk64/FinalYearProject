using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isShooted = false;

    public float speedSetoff = 100f;

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



        }
    }
}
