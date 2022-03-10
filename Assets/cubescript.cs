using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class cubescript : MonoBehaviour
{
    float createCubeTimer = 0;
    float timePast = 0;

    int black = 0;
    int Corrects1 = 0;
    int Corrects2 = 0;
    int Corrects3 = 0;
    int Corrects4 = 0;
    int Incorrects1 = 0;
    int Incorrects2 = 0;
    int Incorrects3 = 0;
    int Incorrects4 = 0;

    bool correct = false;

    bool hit = false;    
    
    GameObject cube;

    public class data 
    {
    public bool hit;
    public int black;
     public bool correct;
    public float timePast;

    public int Corrects1;
    public int Corrects2; 
    public int Corrects3; 
    public int Corrects4; 
    public int Incorrects1; 
    public int Incorrects2; 
    public int Incorrects3;
    public int Incorrects4; 
    }
    List<data> allData = new List<data>();
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
        for (int i = 0; i < cubes.Count; i++)
        {
            if (collision.gameObject.name == cubes[i].name)
            {   
                if(black == 1){
            correct = true;
            if (timePast > 90)
                Corrects4++;
            else if (timePast > 60)
                Corrects3++;
            else if (timePast > 30)
                Corrects2++;
            else if (timePast > 0)
                Corrects1++;

                    
                
                Debug.Log("corrects: " + Corrects1);
            }
            else{
                correct = false;
                if (timePast > 90)
                    Incorrects4++;
                else if (timePast > 60)
                    Incorrects3++;
                else if (timePast > 30)
                    Incorrects2++;
                else if (timePast > 0)
                    Incorrects1++;

                Debug.Log("Incorrects: " + Incorrects1);
            }
                hit = true;
                cubes[i].GetComponent<Rigidbody>().useGravity = true;
                Destroy(cubes[i], 2);
                cubes.RemoveAt(i);
                break;
            }
        }
        
        
        
    }
    // Update is called once per frame
    void Update()
    {  if( timePast < 120){
        hit = false; 
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
                
                if (!hit && black == 0){
            correct = true;
            if (timePast > 90)
                Corrects4++;
            else if (timePast > 60)
                Corrects3++;
            else if (timePast > 30)
                Corrects2++;
            else if (timePast > 0)
                Corrects1++;
                    Debug.Log("corrects: " + Corrects1);
                }
            else if(!hit && black == 1){
            correct = false;
            if (timePast > 90)
                Incorrects4++;
            else if (timePast > 60)
                Incorrects3++;
            else if (timePast > 30)
                Incorrects2++;
            else if (timePast > 0)
                Incorrects1++;
            Debug.Log("Incorrects: " + Incorrects1);
                }

                Destroy(cubes[i]);
                cubes.RemoveAt(i);
                
            }
        }
        createCubeTimer -= Time.deltaTime;
        timePast += Time.deltaTime;

        data acquiredData = new data();
        acquiredData.black = black;
        acquiredData.hit = hit;
        acquiredData.correct = correct;
        acquiredData.Corrects1 = Corrects1;
        acquiredData.Corrects2 = Corrects2;
        acquiredData.Corrects3 = Corrects3;
        acquiredData.Corrects4 = Corrects4;
        acquiredData.Incorrects1 = Incorrects1;
        acquiredData.Incorrects2 = Incorrects2;
        acquiredData.Incorrects3 = Incorrects3;
        acquiredData.Incorrects4 = Incorrects4;

        allData.Add(acquiredData);
        
    }}

}


