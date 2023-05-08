using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pose : MonoBehaviour
{
    [SerializeReference] private GameObject poseScreen;
    [SerializeReference] private GameObject optionScreen;
    [SerializeReference] private GameObject checkStage;
    [SerializeReference] private GameObject checkTitle;

    private GameObject Stage;
    private GameObject Stage2;
    private GameObject Option;
    private GameObject Option2;
    private GameObject Title;
    private GameObject Title2;

    private int poseNum;            //ポーズ画面選択判定用
    private bool activePose;        //ポーズ画面の表示判定用

    static public bool activetoStage;     //ステージ確認画面表示判定
    static public bool activetoOption;    //オプション表示判定
    static public bool activetoTitle;     //タイトル確認画面表示判定

    private void Start()
    {
        Stage   = GameObject.Find("StageSelect");
        Stage2  = GameObject.Find("StageSelect2");
        Option  = GameObject.Find("Option");
        Option2 = GameObject.Find("Option2");
        Title   = GameObject.Find("BackTitle");
        Title2  = GameObject.Find("BackTitle2");

        poseScreen.SetActive(false);
        optionScreen.SetActive(false);
        checkStage.SetActive(false);
        checkTitle.SetActive(false);

        activePose = false;
        poseNum = 0;
    }

    private void Update()
    {
        if (!activePose && PadInput.GetKeyDown(KeyCode.JoystickButton2))
        {
            //ゲームシーンの停止
            Time.timeScale = 0;
            //ポーズ画面の表示  
            poseScreen.SetActive(true);
            //表示判定の更新
            activePose = true;
        }

        if (activePose && PadInput.GetKeyDown(KeyCode.JoystickButton1))
        {
            //ポーズ画面の非表示  
            poseScreen.SetActive(false);
            //ゲームシーンの再生
            Time.timeScale = 1;
            //表示判定の更新
            activePose = false;
        }

        if(activePose)
        {
            //選択の更新
            poseNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX");

            //選択のループ
            poseNum += 3;
            poseNum %= 3;

            //光るUIの更新
            ChangePoseActive();

            //選択の決定
            if(PadInput.GetKeyDown(KeyCode.JoystickButton0))
            {
                ActiveCanvas();
                activePose = false;
            }         
        }
        
        //表示されている画面のみ(どれか一つに入る)
        //ポーズ画面のみなら全てスルー
        if(activetoStage)
        {
            activePose = false;

            YNChoice.Update();

            if(!activetoStage)
            {
                checkStage.SetActive(false);
            }
        }
        if(activetoOption)
        {
            activePose = false;

            if (!activetoOption)
            {
                optionScreen.SetActive(false);
            }
        }
        if(activetoTitle)
        {
            activePose = false;

            YNChoice.Update();

            if (!activetoTitle)
            {
                checkTitle.SetActive(false);
            }
        }
    }

    private void ActiveCanvas()
    {
        switch (poseNum)
        {
            case 0:
                activetoStage = true;

                //ステージ選択への確認画面
                checkStage.SetActive(true);
                optionScreen.SetActive(false);
                checkTitle.SetActive(false);
                break;

            case 1:
                activetoOption = true;

                //オプション画面表示
                optionScreen.SetActive(true);
                checkTitle.SetActive(false);
                checkTitle.SetActive(false);
                break;

            case 2:
                activetoTitle = true;

                //タイトルへの確認画面
                checkTitle.SetActive(true);
                optionScreen.SetActive(false);
                checkStage.SetActive(false);
                break;
        }
    }

    private void ChangePoseActive()
    {
        switch (poseNum)
        {
            case 0:
                //ステージが光っている
                Stage.SetActive(false);
                Stage2.SetActive(true);
                Option.SetActive(true);
                Option2.SetActive(false);
                Title.SetActive(true);
                Title2.SetActive(false);
                break;

            case 1:
                //オプションが光っている
                Stage.SetActive(true);
                Stage2.SetActive(false);
                Option.SetActive(false);
                Option2.SetActive(true);
                Title.SetActive(true);
                Title2.SetActive(false);
                break;

            case 2:
                //タイトルが光っている
                Stage.SetActive(true);
                Stage2.SetActive(false);
                Option.SetActive(true);
                Option2.SetActive(false);
                Title.SetActive(false);
                Title2.SetActive(true);
                break;
        }
    }
}
