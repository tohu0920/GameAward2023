using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pose : MonoBehaviour
{
    [SerializeReference] private GameObject optionScreen;
    [SerializeReference] private GameObject checkStage;
    [SerializeReference] private GameObject checkTitle;

    private GameObject Stage;
    private GameObject Stage2;
    private GameObject Option;
    private GameObject Option2;
    private GameObject Title;
    private GameObject Title2;

    private YNChoice ynStageChoice;
    private YNChoice ynTitleChoice;

    private int poseNum;            //ポーズ画面選択判定用

    static public bool activePose;        //ポーズ画面の表示判定用
    static public bool activetoStage;     //ステージ確認画面表示判定
    static public bool activePoseOption;  //オプション表示判定
    static public bool activetoTitle;     //タイトル確認画面表示判定

    private void Start()
    {
        Stage   = GameObject.Find("StageSelect");
        Stage2  = GameObject.Find("StageSelect2");
        Option  = GameObject.Find("Option");
        Option2 = GameObject.Find("Option2");
        Title   = GameObject.Find("BackTitle");
        Title2  = GameObject.Find("BackTitle2");
        ynStageChoice = checkStage.GetComponent<YNChoice>();

        optionScreen.SetActive(false);
        checkStage.SetActive(false);
        checkTitle.SetActive(false);

        activePose = false;
        poseNum = 0;
    }

    private void Update()
    {        
        if (activePose)
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
        
        //表示されている画面のみ動作(どちらかに入る)
        //ポーズ画面のみなら全てスルー
        if(activetoStage)
        {
            ynStageChoice.Update();

            //一つ戻る
            if(!activetoStage)
            {
                checkStage.SetActive(false);
                activePose = true;
            }
        }
        if(activetoTitle)
        {
            ynTitleChoice.Update();

            if (!activetoTitle)
            {
                checkTitle.SetActive(false);
                activePose = true;
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
                activePoseOption = true;

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

    /// <summary>
    /// この関数を呼び出すScriptでSirializeRefarenceでposeCanvasを取得しから
    /// オンオフ切り替えるのと同時に呼び出すこと
    /// </summary>
    static public void ActivePoseSCreen()
    {
        //ゲームシーンの停止
        Time.timeScale = 0;
        //表示判定の更新
        activePose = true;
    }
    static public void NonActivePoseSCreen()
    {
        //ゲームシーンの再生
        Time.timeScale = 1;
        //表示判定の更新
        activePose = false;
    }
}
