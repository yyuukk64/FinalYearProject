using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPrimitive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0.5f, 0);

        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0, 1.5f, 0);

        sphere.transform.SetParent(cube.transform);
        cube2.transform.SetParent(cube.transform);
        cube2.transform.localScale = new Vector3(.8f, .4f, .4f);
        cube2.transform.localPosition = new Vector3(0, 1.088f, 0.227f);
        cube.AddComponent<Rigidbody>();


        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(2, 1, 0);

        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(-2, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
