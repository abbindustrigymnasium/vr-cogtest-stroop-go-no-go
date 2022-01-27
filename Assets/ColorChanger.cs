using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public TMP_Text m_TextComponent;

    int textNumber;
    int textColor;


    void Start()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        

        m_TextComponent.text = "Red";
        m_TextComponent.color = new Color32(255, 128, 0, 255);

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
        textNumber = Random.Range(1, 5);
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
        textColor = Random.Range(1, 5);
        switch (textColor)
        {
            case 1:
                m_TextComponent.color = new Color32(255, 0, 0, 255);
                break;
            case 2:
                m_TextComponent.color = new Color32(0, 0, 255, 255);
                break;
            case 3:
                m_TextComponent.color = new Color32(255, 255, 0, 255);
                break;
            case 4:
                m_TextComponent.color = new Color32(0, 255, 0, 255);
                break;
            default:
                m_TextComponent.color = new Color32(255, 0, 0, 255);
                break;
        }
        }
    }
}
