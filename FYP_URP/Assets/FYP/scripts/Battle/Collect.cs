using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    Following following;
    TheQueue theQueue;

    [SerializeField] GameObject thisGameObject;
    bool canCollect = true;

    // Start is called before the first frame update
    void Start()
    {
        following = FindObjectOfType<Following>();
        theQueue = FindObjectOfType<TheQueue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && thisGameObject.GetComponent<Collect>().canCollect)
        {
            thisGameObject.GetComponent<Following>().follow = theQueue.returnLastGameobject();
            theQueue.AddToQueue(thisGameObject);
            thisGameObject.GetComponent<Collect>().canCollect = false;
        }
    }
}
