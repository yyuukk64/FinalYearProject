using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Ivy : MonoBehaviour
{
    bool canCut = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canCut && Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.SetActive(false);

            //save...
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            //Dialogue...

            Debug.Log("You can't do it");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canCut = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canCut = false;
    }
}
