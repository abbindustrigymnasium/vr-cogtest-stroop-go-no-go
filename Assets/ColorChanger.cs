using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public TMP_Text m_TextComponent;

    // Start is called before the first frame update
    void Start()
    {
        //textObject.text = "RED";
        //gameObject.GetComponent<Text>().text = "Your string here, yo!";
        //Text textObject = GameObject.Find("textObject");
        m_TextComponent = GetComponent<TMP_Text>();
        m_TextComponent.text = "Red";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
