using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCrystalRotation : MonoBehaviour
{
    [SerializeField] GameObject Crystal;
    public float Speed = 1;
    private float rotY;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotY += Time.deltaTime * Speed;

        if (rotY == 360)
        {
            rotY = 0;
        }

        Crystal.transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
