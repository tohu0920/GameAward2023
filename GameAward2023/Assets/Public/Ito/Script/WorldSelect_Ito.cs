using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldSelect_Ito : MonoBehaviour
{
    public enum WorldNum
    {
        World3 = 1,     //第３階層
        World2,         //第２階層
        World1,         //第１階層
        MAX
    }
    public enum StageNum
    {
        Stage1 = 1,     //ステージ１
        Stage2,     //ステージ２
        Stage3,     //ステージ３
        Stage4,     //ステージ４
        Stage5,     //ステージ５
        Stage6,     //ステージ６
        Stage7,     //ステージ７
        Stage8,     //ステージ８
        Stage9,     //ステージ９
        Stage10,    //ステージ１０
        Max,
    }

    [SerializeReference] GameObject World1;
    [SerializeReference] GameObject World2;
    [SerializeReference] GameObject World3;
    [SerializeReference] GameObject W1Stage;
    [SerializeReference] GameObject W2Stage;
    [SerializeReference] GameObject W3Stage;

    private GameObject WorldCtrlObj;
    private GameObject StageCtrlObj;

    public int unlockstage1Num = 0;　//ステージ解放用
    public int LoadSceneNum = 0;     //ステージロード用
    public static WorldNum worldNum;
    public static StageNum stageNum;

    private string Scene;

    private int oldSelectNum;
    private bool activeWorld;
    private bool activeStage;

    private RectList RectChange;

    public int SSelectNum;

    // Start is called before the first frame update
    void Start()
    {
        //コントロールオブジェクト
        StageCtrlObj = GameObject.Find("StageCtrlObj");
        RectChange = W3Stage.GetComponent<RectList>();

        //初期化      
        SSelectNum = 0;
        oldSelectNum = 99;
        unlockstage1Num = 1;
        activeWorld = true;
        activeStage = false;

        //シーン遷移するステージ名
        Scene = "Ito_KariGameScene";
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面なら実行
        if(activeWorld)
            WorldSelect();
        
        //決定した画面の表示
        if(PadInput.GetKeyDown(KeyCode.JoystickButton0))
        {
            activeWorld = false;
            ActiveStageList();
        }

        if(activeStage)
        {
            SelectStage();
        }
    }

    private void WorldSelect()
    {
        //ステージ選択の入力処理
        worldNum += AxisInput.GetAxisRawRepeat("Vertical_PadX");

        //ステージ選択をループせずに止める
        if (worldNum == WorldNum.World1 - 1)
        {
           worldNum = WorldNum.World1;
        }
        if (worldNum == WorldNum.World2 + 1)
        {
            worldNum = WorldNum.World3;
        }

        //ワールドの変更
        WorldChange();
    }

    private void WorldChange()
    {
        switch (worldNum)
        {
            case WorldNum.World1:
                World1.SetActive(true);
                World2.SetActive(false);
                World3.SetActive(false);
                break;

            case WorldNum.World2:
                World1.SetActive(false);
                World2.SetActive(true);
                World3.SetActive(false);
                break;

            case WorldNum.World3:
                World1.SetActive(false);
                World2.SetActive(false);
                World3.SetActive(true);
                break;
        }
    }

    private void ActiveStageList()
    {
        switch(worldNum)
        {
            case WorldNum.World1:
                World1.SetActive(false);
                W1Stage.SetActive(true);
                break;

            case WorldNum.World2:
                World2.SetActive(false);
                W2Stage.SetActive(true);
                break;

            case WorldNum.World3:
                World2.SetActive(false);
                W2Stage.SetActive(true);
                break;
        }
        activeStage = true;
    }

    private void SelectStage()
    {
        stageNum += AxisInput.GetAxisRawRepeat("Horizontal_PadX");
        stageNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX") * 5;

        if (stageNum == StageNum.Stage1 - 1)
        {
            stageNum = StageNum.Stage10;
        }
        if (stageNum == StageNum.Stage10 + 1)
        {
            stageNum = StageNum.Stage1;
        }

        switch (stageNum)
        {
            case StageNum.Stage1:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 1)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage1;
                        SceneManager.LoadScene(Scene);
                    }
                }

                oldSelectNum = 1;
                break;

            case StageNum.Stage2:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 2)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage2;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 2;
                break;

            case StageNum.Stage3:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 3)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage3;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 3;
                break;

            case StageNum.Stage4:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 4)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage4;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 4;
                break;

            case StageNum.Stage5:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 5)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage5;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 5;
                break;

            case StageNum.Stage6:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 6)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage6;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 6;
                break;

            case StageNum.Stage7:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 7)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage7;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 7;
                break;

            case StageNum.Stage8:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 8)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage8;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 8;
                break;

            case StageNum.Stage9:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 9)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage9;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 9;
                break;

            case StageNum.Stage10:
                RectChange.SetSizeImage(1, 1.5f);
                RectChange.SetSizeImage(oldSelectNum, 2.0f);

                if (unlockstage1Num >= 10)
                {
                    if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        LoadSceneNum = (int)StageNum.Stage10;
                        SceneManager.LoadScene(Scene);
                    }
                }
                oldSelectNum = 10;
                break;
        }

        if (PadInput.GetKeyDown(KeyCode.JoystickButton1))
        {
            ReturnWorld();
        }
    }

    private void ReturnWorld()
    {
        switch (worldNum)
        {
            case WorldNum.World1:
                World1.SetActive(true);
                W1Stage.SetActive(false);
                break;

            case WorldNum.World2:
                World2.SetActive(true);
                W2Stage.SetActive(false);
                break;

            case WorldNum.World3:
                World2.SetActive(true);
                W2Stage.SetActive(false);
                break;
        }
        activeStage = false;
    }
}
