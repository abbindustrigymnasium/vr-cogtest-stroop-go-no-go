using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour
{
    float createCubeTimer = 0;
    float timePast = 1;

    int black = 0;

    GameObject cube;

    List<GameObject> cubes = new List<GameObject>();

    void AddCube()
    {
        black = Random.Range(0,2);
        
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 1.5f, 0);
        if(black == 1)
        {
            cube.GetComponent<Renderer>().material.color = Color.black;
        }
        else{
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
            createCubeTimer = 4 - 0.031f* timePast;
        }

        // Move the object forward along its z axis 1 unit/second.
        for(int i = 0; i < cubes.Count; i++)
        {
            cubes[i].transform.Translate(Vector3.forward * -1 * (0.03f + 0.02f * Time.deltaTime));
            if(cubes[i].transform.position[2] < Camera.main.transform.position[2])
            {
                Destroy(cubes[i]);
                cubes.RemoveAt(i);
                
            }
        }
        createCubeTimer -= Time.deltaTime;
        timePast += Time.deltaTime;
        
    }

}
