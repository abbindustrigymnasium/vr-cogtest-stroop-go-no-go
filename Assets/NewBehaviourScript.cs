using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour


{
    public GameObject Instructions;
    // Start is called before the first frame update
    void Start()
    {
        Instructions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instructions.SetActive(false);
        }
    }
}
