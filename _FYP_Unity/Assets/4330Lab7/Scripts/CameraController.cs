using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float followAhead;

    private Vector3 targetPosition;

    public float smoothing;
    
    void Update()
    {
        if (player.transform.localScale.x > 0f)
        {
            targetPosition = new Vector3(player.transform.position.x + followAhead, transform.position.y, transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(player.transform.position.x - followAhead, transform.position.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing* Time.deltaTime);
    }
}
