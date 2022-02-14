using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour
{
    float createCubeTimer = 0;

    GameObject cube;

    void Start()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (createCubeTimer <= 0)
        {
            
            createCubeTimer = 5;
        }

        // Move the object forward along its z axis 1 unit/second.
        cube.transform.Translate(Vector3.forward * Time.deltaTime*-1);
        
    }

}
