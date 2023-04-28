using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    PlayerMovement m_movement;

    private void Awake()
    {
        m_movement = FindObjectOfType<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_movement.canMove = false;
    }
}
