using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform[] VerticalPos = new Transform[7];
    public Transform[] HorizontalPos = new Transform[9];
    Vector3 BeamPosFix_H = new Vector3(6f, 0f, 0f); 

    [SerializeField] GameObject BlueBeam;

    



    // Start is called before the first frame update
    void Start()
    {
        BeamAttack_H(Random.RandomRange(0, 7));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeamAttack_V(int i)
    {
        Instantiate(BlueBeam, HorizontalPos[i].position , Quaternion.Euler(0, 90, 0));
    }

    public void BeamAttack_H(int i)
    {
        if (i > 6)
            i = 6;
        if (i < 0)
            i = 0;
        Instantiate(BlueBeam, VerticalPos[i].position + BeamPosFix_H, Quaternion.identity);
        Debug.Log(i);
    }
}
