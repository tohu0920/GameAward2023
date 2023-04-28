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
    private TitleAnimation titleAnimation;

    public int SelectNum;

    [SerializeReference] GameObject GameScreen;
    [SerializeReference] GameObject OptionScreen;
    [SerializeReference] GameObject kari;


    // Start is called before the first frame update
    void Start()
    {
        StartImage = GameObject.Find("Start");
        OptionImage = GameObject.Find("Option");
        EndImage = GameObject.Find("End");
        UnderLine = GameObject.Find("UnderLine").GetComponent<Image>();
        titleAnimation = GameObject.Find("core").GetComponent<TitleAnimation>();

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
                    //タイトルアニメーション再生
                    titleAnimation.StartAnimetion();

                    //アニメーション終了後シーン遷移
                    if( titleAnimation.isPlaying == false)
                    {
                        LoadSelectScene();
                    }
                    break;

                case 1:
                        //オプション画面の表示
                        GameScreen.SetActive(false);
                        OptionScreen.SetActive(true);
                        kari.SetActive(false);
                    break;

                case 2:
                        //ゲーム終了
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

