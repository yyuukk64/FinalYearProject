using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheQueue : MonoBehaviour
{
    public List<GameObject> _Queue = new List<GameObject>();

   public void AddToQueue(GameObject _new)
    {
        _Queue.Add(_new);
    }

    public Transform returnLastGameobject()
    {
        return _Queue[_Queue.Count - 1].transform;
    }
}
