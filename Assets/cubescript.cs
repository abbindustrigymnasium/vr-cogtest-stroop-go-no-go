using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour
{
    float createCubeTimer = 0;
    float timePast = 0;

    int black = 0;

    GameObject cube;

    List<GameObject> cubes = new List<GameObject>();

    void AddCube()
    {
        black = Random.Range(0,2);
        
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 1.5f, 0);
        cube.AddComponent<BoxCollider>();
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().useGravity = false;
        if(black == 1)
        {
            cube.GetComponent<Renderer>().material.color = Color.black;
        }
        else
        {
            cube.GetComponent<Renderer>().material.color = Color.red;
        }
        cubes.Add(cube);
    }

    void Start()
    {
        AddCube();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (createCubeTimer <= 0)
        {
            AddCube();
            if (timePast > 90)
                createCubeTimer = 0.666f;
            else if (timePast > 60)
                createCubeTimer = 0.888f;
            else if (timePast > 30)
                createCubeTimer = 1.110f;
            else if (timePast >= 0)
                createCubeTimer = 1.332f;
        }

        // Move the object forward along its z axis 1 unit/second.
        for(int i = 0; i < cubes.Count; i++)
        {

            if (timePast > 90)
                cubes[i].transform.Translate(Vector3.forward * 6.0f *Time.deltaTime*-1);
            else if (timePast > 60)
                cubes[i].transform.Translate(Vector3.forward * 5.0f * Time.deltaTime * -1);
            else if (timePast > 30)
                cubes[i].transform.Translate(Vector3.forward * 4.0f * Time.deltaTime * -1);
            else if (timePast > 0)
                cubes[i].transform.Translate(Vector3.forward * 3.0f * Time.deltaTime * -1);

            if (cubes[i].transform.position[2] < Camera.main.transform.position[2])
            {
                Destroy(cubes[i]);
                cubes.RemoveAt(i);
                
            }
        }
        createCubeTimer -= Time.deltaTime;
        timePast += Time.deltaTime;
        
    }

}
