using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    //the object to follow
    public Transform follow;

    //max allowed distance
    [SerializeField] float maxDistance = 2;

    // Angular speed in radians per sec.
    [SerializeField] float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float actualDistance = Vector3.Distance(transform.position, follow.position);
        if (actualDistance > maxDistance)
        {
            var followToCurrent = (transform.position - follow.position).normalized;
            followToCurrent.Scale(new Vector3(maxDistance, maxDistance, maxDistance));

            //set the new position
            transform.position = follow.position + followToCurrent;

            //Rotate..
            // Determinie which direction to rotate towards 
            Vector3 targetDirection = follow.position - transform.position;
            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;
            //Rotate the forward vector rowards the target diretion by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
