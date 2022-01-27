using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public TMP_Text m_TextComponent;

    int textNumber;


    void Start()
    {
        m_TextComponent = GetComponent<TMP_Text>();

        m_TextComponent.text = "Red";

    }

    void Update()
    {

        textNumber = Random.Range(1, 4);
        switch (textNumber)
        {
            case 1:
                m_TextComponent.text = "Red";
                break;
            case 2:
                m_TextComponent.text = "blue";
                break;
            case 3:
                m_TextComponent.text = "Yellow";
                break;
            case 4:
                m_TextComponent.text = "Green";
                break;
            default:
                m_TextComponent.text = "Red";
                break;
        }
    }
}
