using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheQueue : MonoBehaviour
{
    public List<GameObject> _Queue = new List<GameObject>();

    public Vector3 worldPosition;
    Plane plane = new Plane(new Vector3(0, 2, 0), 0);

    [SerializeField]
    AudioSource InShooting;

    public void AddToQueue(GameObject _new)
    {
        _Queue.Add(_new);
    }

    public Transform returnLastGameobject()
    {
        return _Queue[_Queue.Count - 1].transform;
    }

    public void LeaveFromQueue()
    {
        _Queue.Remove(_Queue[1]);
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && _Queue.Count > 1)
        {
            _Queue[1].GetComponent<Following>().follow = _Queue[1].transform;

            shoot();

            LeaveFromQueue();

            for (int i = 1; i < _Queue.Count; i++)
            {
                _Queue[i].GetComponent<Following>().follow = _Queue[i - 1].transform;
            }
        }
    }

    public void shoot()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
        _Queue[1].transform.LookAt(worldPosition);

        _Queue[1].GetComponent<Shooting>().isShooted = true;

        InShooting.Play();
    }
}
