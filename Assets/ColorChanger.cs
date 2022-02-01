using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public TMP_Text m_TextComponent;
    public GameObject sphereComponent;

    int textNumber = 1;
    int textColor = 1;
    int Black = 1;


    void Start()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        
        

        // m_TextComponent.text = "Red";
        // m_TextComponent.color = new Color32(255, 128, 0, 255);

    }

    void Update()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4"))
        {
            if (Black == 2 && Input.GetKeyDown(textNumber.ToString()))
            {
                Debug.Log("Point!" + textNumber.ToString());
            }
            else if (Black == 1 && Input.GetKeyDown(textColor.ToString()))
            {
                Debug.Log("Cool Point!" + textColor.ToString());
            }
            Black = Random.Range(1, 3);
            switch (Black){
                case 1: 
                    sphereComponent.SetActive(true);
                    break;
                case 2:
                    sphereComponent.SetActive(false);
                    break;
            }
            textNumber = Random.Range(1, 5);
            switch (textNumber)
            {
                case 1:
                    m_TextComponent.text = "Red";
                    break;
                case 2:
                    m_TextComponent.text = "Blue";
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
                    m_TextComponent.color = new Color32(255, 240, 57, 255);
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
