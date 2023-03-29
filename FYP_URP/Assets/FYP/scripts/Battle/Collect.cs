using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    TheQueue theQueue;

    [SerializeField] GameObject thisGameObject;
    public bool canCollect = true;

    // Start is called before the first frame update
    void Start()
    {
        theQueue = FindObjectOfType<TheQueue>();
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
