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

        Random rnd = new Random();

        m_TextComponent.text = "Red";

    }

    void Update()
    {
        textNumber = rnd.next(1, 4);
        switch (textNumber)
    }
}
