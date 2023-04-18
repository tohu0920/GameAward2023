using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    private Image S0Image;
    private Image S1Image;
    private Image S2Image;
    private Image S3Image;
    private Image S4Image;
    private Image S5Image;
    private Image S6Image;
    private Image S7Image;
    private Image S8Image;
    private Image S9Image;
    private Image S10Image;


    [SerializeReference] GameObject mainselectScreen;
    [SerializeReference] GameObject subselsectScreen;
    [SerializeReference] GameObject Empty;
    [SerializeReference] Object Scene;

    public static int SelectNum;            //ステージ選択用
    public static int unlockstage1Num = 0;　//ステージ解放用

    public  enum StageSelect
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Stage6,
        Stage7,
        Stage8,
        Stage9,
        Stage10,
    }
   
    // Start is called before the first frame update
    void Start()
    {
        S0Image = GameObject.Find("S0").GetComponent<Image>();
        S1Image = GameObject.Find("S1").GetComponent<Image>();
        S2Image = GameObject.Find("S2").GetComponent<Image>();
        S3Image = GameObject.Find("S3").GetComponent<Image>();
        S4Image = GameObject.Find("S4").GetComponent<Image>();
        S5Image = GameObject.Find("S5").GetComponent<Image>();
        S6Image = GameObject.Find("S6").GetComponent<Image>();
        S7Image = GameObject.Find("S7").GetComponent<Image>();
        S8Image = GameObject.Find("S8").GetComponent<Image>();
        S9Image = GameObject.Find("S9").GetComponent<Image>();
        S10Image = GameObject.Find("S10").GetComponent<Image>();
        

        S1Image.color = new Color(255, 0, 0, 255);

        SelectNum = 1;
        unlockstage1Num = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SelectNum += AxisInput.GetAxisRawRepeat("Horizontal");
        SelectNum -= AxisInput.GetAxisRawRepeat("Vertical") * 5;       

        if (SelectNum == -1)
        {
            SelectNum = 10;
        }
        if(SelectNum == 11)
        {
            SelectNum = 1;
        }        
        if (SelectNum >= 12)
        {
            SelectNum -= 5;
        }
        if(SelectNum <= -2)
        {
            SelectNum += 5;
        }

        switch (SelectNum)
        {
            case 1:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 0, 0, 255);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255, 255, 255, 125);
                
                if(unlockstage1Num >= 1)
                {
                    if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                        
                    }
                }

                break;

            case 2:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 0, 0, 255);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255, 255, 255, 125);

                if (unlockstage1Num >= 2)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                break;

            case 3:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 0, 0, 255);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255, 255, 255, 125);

                if (unlockstage1Num >= 3)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                break;

            case 4:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 0, 0, 255);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255, 255, 255, 125);

                if (unlockstage1Num >= 4)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                break;

            case 5:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 0, 0, 255);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255, 255, 255, 125);

                if (unlockstage1Num >= 5)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                
                break;

            case 6:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 0, 0, 255);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255, 255, 255, 125);

                if (unlockstage1Num >= 6)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                break;

            case 7:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 0, 0, 255);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255,255, 255, 125);

                if (unlockstage1Num >= 7)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                break;

            case 8:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 0, 0, 255);
                S9Image.color = new Color(255, 255, 255, 125);
                S10Image.color = new Color(255, 255, 255, 125);

                if (unlockstage1Num >= 8)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                break;
           
            case 9:
                S0Image.color = new Color(255, 255, 255, 125);
                S1Image.color = new Color(255, 255, 255, 125);
                S2Image.color = new Color(255, 255, 255, 125);
                S3Image.color = new Color(255, 255, 255, 125);
                S4Image.color = new Color(255, 255, 255, 125);
                S5Image.color = new Color(255, 255, 255, 125);
                S6Image.color = new Color(255, 255, 255, 125);
                S7Image.color = new Color(255, 255, 255, 125);
                S8Image.color = new Color(255, 255, 255, 125);
                S9Image.color = new Color(255, 0, 0, 255);
                S10Image.color = new Color(255, 255, 255, 125);

                if (unlockstage1Num >= 9)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        SceneManager.LoadScene(Scene.name);
                    }
                }
                break;
        }

        if(SelectNum == 10)
        {
            S0Image.color = new Color(255, 255, 255, 125);
            S1Image.color = new Color(255, 255, 255, 125);
            S2Image.color = new Color(255, 255, 255, 125);
            S3Image.color = new Color(255, 255, 255, 125);
            S4Image.color = new Color(255, 255, 255, 125);
            S5Image.color = new Color(255, 255, 255, 125);
            S6Image.color = new Color(255, 255, 255, 125);
            S7Image.color = new Color(255, 255, 255, 125);
            S8Image.color = new Color(255, 255, 255, 125);
            S9Image.color = new Color(255, 255, 255, 125);
            S10Image.color = new Color(255, 0, 0, 255);

            if (unlockstage1Num >= 10)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    SceneManager.LoadScene(Scene.name);
                }
            }
        }

        if(SelectNum == 0)
        {
            S0Image.color = new Color(255, 0, 0, 255);
            S1Image.color = new Color(255, 255, 255, 125);
            S2Image.color = new Color(255, 255, 255, 125);
            S3Image.color = new Color(255, 255, 255, 125);
            S4Image.color = new Color(255, 255, 255, 125);
            S5Image.color = new Color(255, 255, 255, 125);
            S6Image.color = new Color(255, 255, 255, 125);
            S7Image.color = new Color(255, 255, 255, 125);
            S8Image.color = new Color(255, 255, 255, 125);
            S9Image.color = new Color(255, 255, 255, 125);
            S10Image.color = new Color(255, 255, 255, 125);
           
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                mainselectScreen.SetActive(true);
                subselsectScreen.SetActive(false);
                Empty.SetActive(true);
            }            
        }
    }
}
