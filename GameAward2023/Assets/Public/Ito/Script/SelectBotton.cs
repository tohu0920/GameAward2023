using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectBotton : MonoBehaviour
{
    private GameObject StartImage;       
    private GameObject OptionImage;    
    private GameObject EndImage;
    private Image UnderLine;

    [SerializeReference] GameObject GameScreen;
    [SerializeReference] GameObject OptionScreen;
    [SerializeReference] GameObject kari;

    public int SelectNum;

    // Start is called before the first frame update
    void Start()
    {
        StartImage = GameObject.Find("Start");
        OptionImage = GameObject.Find("Option");
        EndImage = GameObject.Find("End");
        UnderLine = GameObject.Find("UnderLine").GetComponent<Image>();

        UnderLine.rectTransform.anchoredPosition = new Vector2(0, -180);        
        SelectNum = 0;       
    }

    // Update is called once per frame
    void Update()
    {
        SelectNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX");

        //選択のループ
        if (SelectNum == -1) //２行でまとめる (if文使わずに)
        {
            SelectNum = 2;       
        }
        if (SelectNum == 3)
        {
            SelectNum = 0;
        }

        //ラインのポジションをまとめる(swtich使わずに)改行あり
        UnderLine.rectTransform.anchoredPosition = new Vector2(0, -180 - SelectNum * 70);

        switch (SelectNum)
        {
            case 0:
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

    /// <summary>
    /// タイトルシーンのロードシーン用
    /// </summary>
    private void LoadSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");        
    }
}

