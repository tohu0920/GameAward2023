using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TitleSceneAnimation;


public class SelectBotton : MonoBehaviour
{
    private GameObject StartImage;       
    private GameObject OptionImage;    
    private GameObject EndImage;
    private Image UnderLine;
    private TitleSceneAnimation titleAnimation;

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
        titleAnimation = GameObject.Find("core").GetComponent<TitleSceneAnimation>();

        UnderLine.rectTransform.anchoredPosition = new Vector2(0, -180);        
        SelectNum = 0;       
    }

    // Update is called once per frame
    void Update()
    {
        SelectNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX");

        //選択のループ
        SelectNum += 3;
        SelectNum %= 3;
        

        //ラインのポジションをまとめる(swtich使わずに)改行あり
        UnderLine.rectTransform.anchoredPosition = new Vector2(0, -180 - SelectNum * 70);

        if(PadInput.GetKeyDown(KeyCode.JoystickButton0))
        {
            switch (SelectNum)
            {
                case 0:
                    ///titleAnimation.StartAnimation();

                    if( titleAnimation.isPlaying == false)
                    {
                        LoadSelectScene();
                    }
                    break;

                case 1:
                        GameScreen.SetActive(false);
                        OptionScreen.SetActive(true);
                        kari.SetActive(false);
                    break;

                case 2:
                        Application.Quit();
                    break;
            }
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

