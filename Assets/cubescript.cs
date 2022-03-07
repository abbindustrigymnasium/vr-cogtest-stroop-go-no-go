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
        // AddCube();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        for (int i = 0; i < cubes.Count; i++)
        {
            if (collision.gameObject.name == cubes[i].name)
            {
                cubes[i].GetComponent<Rigidbody>().useGravity = true;
                Destroy(cubes[i], 2);
                cubes.RemoveAt(i);
                break;
            }
        }
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (createCubeTimer <= 0)
        {
            AddCube();
            if (timePast > 90)
                createCubeTimer = 1.222f;
            else if (timePast > 60)
                createCubeTimer = 1.6666f;
            else if (timePast > 30)
                createCubeTimer = 2.220f;
            else if (timePast >= 0)
                createCubeTimer = 2.664f;
        }

        // Move the object forward along its z axis 1 unit/second.
        for(int i = 0; i < cubes.Count; i++)
        {

            if (timePast > 90)
                cubes[i].transform.Translate(Vector3.forward * 12.0f *Time.deltaTime*-1);
            else if (timePast > 60)
                cubes[i].transform.Translate(Vector3.forward * 10.0f * Time.deltaTime * -1);
            else if (timePast > 30)
                cubes[i].transform.Translate(Vector3.forward * 8.0f * Time.deltaTime * -1);
            else if (timePast > 0)
                cubes[i].transform.Translate(Vector3.forward * 6.0f * Time.deltaTime * -1);

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
