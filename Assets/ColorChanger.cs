using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public TMP_Text m_TextComponent;
    public TMP_Text m_TextComponent2;
    public GameObject sphereComponent;
    public AudioSource correctSound;
    public AudioSource wrongSound;

    int textNumber = 1;
    int textColor = 1;
    int Black = 1;
    int right = 0;
    int nrOfRight = 0;
    int nrOfWrong = 0;
    int pressedButton = 0;

    float timeLimit = 120; // time limit in seconds
    float timePassed = 0; // time passed since start
    float timeToPress = 0; // time taken to press the button

    public class data
    {
        public int textNumber;
        public int textColor;
        public int Black;
        public int right;
        public int pressedButton;

        public float timePassed;
        public float timeToPress;
    }

    List<data> allData = new List<data>();


    void Start()
    {
        m_TextComponent = GameObject.Find("colourText").GetComponent<TMP_Text>();
        m_TextComponent2 = GameObject.Find("pointCounter").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (timePassed < timeLimit)
        {
            timePassed += Time.deltaTime;
            timeToPress += Time.deltaTime;

            //m_TextComponent2.text = "Teeeext";
            if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4"))
            {

                if (Input.GetKeyDown("1"))
                {
                    pressedButton = 1;
                }
                else if (Input.GetKeyDown("2"))
                {
                    pressedButton = 2;
                }
                else if (Input.GetKeyDown("3"))
                {
                    pressedButton = 3;
                }
                else if (Input.GetKeyDown("4"))
                {
                    pressedButton = 4;
                }

                if (Black == 2 && Input.GetKeyDown(textNumber.ToString()))
                {
                    nrOfRight += 1;
                    right = 1;
                    correctSound.Play();
                }
                else if (Black == 1 && Input.GetKeyDown(textColor.ToString()))
                {
                    nrOfRight += 1;
                    right = 1;
                    correctSound.Play();
                }
                else
                {
                    nrOfWrong += 1;
                    right = 0;
                    wrongSound.Play();
                }
                //m_TextComponent2.text = "wrong: " + nrOfWrong.ToString() + "\nright: " + nrOfRight.ToString();

                data acquiredData = new data();

                acquiredData.Black = Black;
                acquiredData.textNumber = textNumber;
                acquiredData.textColor = textColor;
                acquiredData.right = right;
                acquiredData.timePassed = timePassed;
                acquiredData.timeToPress = timeToPress;
                acquiredData.pressedButton = pressedButton;

                allData.Add(acquiredData);
                for (int i = 0; i < allData.Count; i++)
                {
                    Debug.Log(allData[i].Black + " | " + allData[i].textNumber + " | " + allData[i].textColor + " | " + allData[i].right + " | " + allData[i].timePassed + " | " + allData[i].timeToPress + " | " + allData[i].pressedButton);
                }
                timeToPress = 0;

                Black = Random.Range(1, 3);
                switch (Black)
                {
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
}
