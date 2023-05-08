using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectBotton : MonoBehaviour
{
    //変数宣言
    private GameObject StartImage;       
    private GameObject OptionImage;    
    private GameObject EndImage;
    private Image UnderLine;
    private int SelectNum;

    //private GameObject titleControleObject;
    [SerializeReference] public GameObject titleScreen;
    [SerializeReference] public GameObject OptionScreen;
    [SerializeReference] public GameObject titleControleObject;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの取得
        StartImage  = GameObject.Find("Start");
        OptionImage = GameObject.Find("Option");
        EndImage    = GameObject.Find("End");
        UnderLine   = GameObject.Find("UnderLine").GetComponent<Image>();

        //アンダーラインの初期化
        UnderLine.rectTransform.anchoredPosition = new Vector2(0, -180);

        //キャンバスの初期化
        OptionScreen.SetActive(false);

        //
        SelectNum = 0;       
    }

    // Update is called once per frame
    void Update()
    {
        //
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
                    LoadSelectScene();
                    break;

                case 1:
                    Debug.Log(OptionScreen == null);
                    Debug.Log(titleScreen == null);
                    Debug.Log(titleControleObject == null);
                    OptionScreen.SetActive(true);
                    titleScreen.SetActive(false);
                    titleControleObject.SetActive(false);
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
        SceneManager.LoadScene("Ito_StageSelectScene");        
    }
}

