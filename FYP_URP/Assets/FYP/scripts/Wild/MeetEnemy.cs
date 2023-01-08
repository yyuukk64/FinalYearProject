using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetEnemy : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [Header("The Enemy would be met in this area")]
    [SerializeField] GameObject[] _Enemy;

    Vector3 oldPosition;
    float distance;
    float wolkedDistance;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = _Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        wolkedDistance += Vector3.Distance(_Player.transform.position, oldPosition);
        oldPosition = _Player.transform.position;

        if(wolkedDistance > 20)
        {
            EnterBattle();
            wolkedDistance = 0;
        }
    }

    void EnterBattle()
    {
        float i = Random.Range(0.0f, 100f);
        Debug.Log("i is " + i);
    }
}
