using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private BoxCollider2D platformCollider;
    private float waitTime = 0.5f;

    void Start()
    {
        platformCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                platformCollider.enabled = false;
                waitTime = 0.5f;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
            platformCollider.enabled = true;
        }
    }
}
