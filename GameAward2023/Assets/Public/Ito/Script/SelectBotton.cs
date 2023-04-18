using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectBotton : MonoBehaviour
{
    private Text StartImage;
    private Text OptionImage;
    private Text EndImage;

    [SerializeReference] GameObject GameScreen;
    [SerializeReference] GameObject OptionScreen;
    [SerializeReference] GameObject kari;

    public int SelectNum;

    // Start is called before the first frame update
    void Start()
    {
        StartImage = GameObject.Find("Start").GetComponent<Text>();
        OptionImage = GameObject.Find("Option").GetComponent<Text>();
        EndImage = GameObject.Find("End").GetComponent<Text>();

        StartImage.color = new Color(255, 0, 0, 255);

        SelectNum = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        SelectNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX");

        if (SelectNum == -1)
        {
            SelectNum = 2;       
        }
        if (SelectNum == 3)
        {
            SelectNum = 0;
        }


        switch (SelectNum)
        {
            case 0:
                StartImage.color = new Color(255, 0, 0, 255);
                OptionImage.color = new Color(255, 256, 256, 255);
                EndImage.color = new Color(255, 255, 255, 255);
                //ロードシーンはここで再度作る
                //if(Input.GetKeyDown("JoystickButton1"))
                //{
                //    LoadSelectScene();
                //}
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    LoadSelectScene();
                }
                    break;
                
            case 1:
                OptionImage.color = new Color(255, 0, 0, 255);
                StartImage.color = new Color(255, 255, 255, 255);
                EndImage.color = new Color(255, 255, 255, 255);
                //if (Input.GetKeyDown("JoystickButton1"))
                //{
                //    GameScreen.SetActive(false);
                //    OptionScreen.SetActive(true);
                //    kari.SetActive(false);
                //}
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameScreen.SetActive(false);
                    OptionScreen.SetActive(true);
                    kari.SetActive(false);
                }
                break;

            case 2:
                EndImage.color = new Color(255, 0, 0, 255);
                StartImage.color = new Color(250, 255, 255, 255);
                OptionImage.color = new Color(255, 255, 255, 255);
                //if (Input.GetKeyDown("JoystickButton1"))
                //{
                //    Application.Quit();
                //}
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Application.Quit();
                }
                break;
        }        
    }

    private void LoadSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");        
    }
}

