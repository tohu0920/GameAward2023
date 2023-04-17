using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStageSelect : MonoBehaviour
{
    [SerializeReference] GameObject firstScreen;
    [SerializeReference] GameObject secondScreen;
    [SerializeReference] GameObject thirdScreen;
    [SerializeReference] GameObject forthScreen;
    [SerializeReference] GameObject firstsubScreen;
    [SerializeReference] GameObject secondsubScreen;
    [SerializeReference] GameObject thirdsubScreen;
    [SerializeReference] GameObject forthsubScreen;
    [SerializeReference] GameObject Empty2;


    public int SelectNum;

    // Start is called before the first frame update
    void Start()
    {
        SelectNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SelectNum += AxisInput.GetAxisRawRepeat("Vertical_PadX");

        if (SelectNum == -1)
        {
            SelectNum = 0;
        }
        if (SelectNum == 4)
        {
            SelectNum = 3;
        }


        switch (SelectNum)
        {
            case 0:               
                    firstScreen.SetActive(true);
                    secondScreen.SetActive(false);
                    thirdScreen.SetActive(false);
                    forthScreen.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    firstsubScreen.SetActive(true);
                    firstScreen.SetActive(false);
                    Empty2.SetActive(false);
                }

                break;

            case 1:
                    firstScreen.SetActive(false);
                    secondScreen.SetActive(true);
                    thirdScreen.SetActive(false);
                    forthScreen.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    secondsubScreen.SetActive(true);
                    secondScreen.SetActive(false);
                }

                break;

            case 2:
                    firstScreen.SetActive(false);
                    secondScreen.SetActive(false);
                    thirdScreen.SetActive(true);
                    forthScreen.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    thirdsubScreen.SetActive(false);
                    thirdScreen.SetActive(false);
                }

                break;

            case 3:
                    firstScreen.SetActive(false);
                    secondScreen.SetActive(false);
                    thirdScreen.SetActive(false);
                    forthScreen.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    forthsubScreen.SetActive(true);
                    forthScreen.SetActive(false);
                }

                break;
        }
    }
}
