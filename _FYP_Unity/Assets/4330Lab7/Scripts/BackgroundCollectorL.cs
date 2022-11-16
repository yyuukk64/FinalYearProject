using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollectorL : MonoBehaviour
{
    float backgroundWidth;
    
    void Start()
    {
        backgroundWidth = GameObject.FindGameObjectWithTag("BG").GetComponent<BoxCollider2D>().size.x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BG")
        {
            Vector2 tempPos = other.transform.position;
            tempPos.x += backgroundWidth * 2;
            other.transform.position = tempPos;
        }
    }
}
