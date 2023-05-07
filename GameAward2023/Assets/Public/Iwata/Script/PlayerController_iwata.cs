using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_iwata : MonoBehaviour
{
    [SerializeField] private GameManager GM;

    // Update is called once per frame
    void Update()
    {
        switch (GM.GameStatus)
        {
            case GameManager.eGameStatus.E_GAME_STATUS_JOINT:
                switch (GM.JointStage.GetComponent<JointStageManager>().JSStatus)
                {//ジャンクステージの状態に合わせた処理をする
                    case JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_SELECT:   
                        //十字ボタン
                        if (GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().m_rotateFrameCnt <= 0)
                        {
                            int axisX = AxisInput.GetAxisRawRepeat("Horizontal_PadX");
                            int axisY = AxisInput.GetAxisRawRepeat("Vertical_PadX");
                            if (axisX != 0 || axisY != 0)
                            {
                                GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().InputAxisCore(axisX, axisY);
                            }
                        }

                        //Aボタン
                        if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                        {
                            GameObject SelectJank = GM.JointStage.Find("JointCanvas").Find("Cursor").GetComponent<CursorController_araki>().SelectJank;
                            // ガラクタではないならスルー
                            if (SelectJank.transform.tag != "Jank" && SelectJank.transform.tag != "Player") return;

                            //ジャンクコントローラーに今選択しているジャンクを登録
                            GM.JointStage.Find("Jank").GetComponent<JankController>().SelectJank = SelectJank;

                            GameObject clone = Instantiate(SelectJank);
                            clone.GetComponent<JankBase_iwata>().Orizin = SelectJank;
                            GM.JointStage.GetComponent<JointStageManager>().JSStatus = JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_PUT;
                            GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().PutJank(clone);

                        }

                        ////Bボタン
                        if(PadInput.GetKeyDown(KeyCode.JoystickButton1))
                        {
                            //カーソルからRayを出す
                            //ぶつかったやつの親がCoreじゃなければコンテニュー
                            //名前にCore_ChildかCoreCenterだったらコンテニュー
                            //コアコントローラーにリリースコアを作ってぶつかったのを消して、オリジンをアクティブに戻す
                        }

                        //if (PadInput.GetKeyDown(KeyCode.JoystickButton1))
                        //{
                        //    if (!GM.JointStage.Find("Preview").gameObject.activeSelf)
                        //    {
                                
                        //    }
                        //    else
                        //    {
                        //        GM.JointStage.Find("Jank").GetComponent<JankController>().ReturnJank();
                        //        GM.JointStage.Find("Preview").gameObject.SetActive(false);
                        //    }
                        //}
                        //------------------
                        //常時選択している面があるわけじゃないからRemoveどうしよう
                        //-------------------------------

                        //Xボタン
                        if (PadInput.GetKeyDown(KeyCode.JoystickButton2))
                        {
                            GM.GameStatus = GameManager.eGameStatus.E_GAME_STATUS_ROT;
                        }
                        break;


                    case JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_PUT:
                        //十字ボタン
                        if (GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().m_rotateFrameCnt <= 0)
                        {
                            int axisX = AxisInput.GetAxisRawRepeat("Horizontal_PadX");
                            int axisY = AxisInput.GetAxisRawRepeat("Vertical_PadX");
                            if (axisX != 0 || axisY != 0)
                            {
                                GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().InputAxisCore(axisX, axisY);
                            }
                        }

                        //Aボタン
                        if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                        {
                            if(GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().JointCore())
                                GM.JointStage.GetComponent<JointStageManager>().JSStatus = JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_SELECT;
                        }

                        //Bボタン
                        if (PadInput.GetKeyDown(KeyCode.JoystickButton1))
                        {
                            GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().CanselCore();
                            GM.JointStage.GetComponent<JointStageManager>().JSStatus = JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_SELECT;
                        }

                        //Lボタン
                        if (PadInput.GetKeyDown(KeyCode.JoystickButton4))
                        {
                            GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().AttachJank.GetComponent<JankBase_iwata>().RotJank(1, 0, GM.JointStage.Find("Core"));
                        }

                        //Lボタン
                        if (PadInput.GetKeyDown(KeyCode.JoystickButton5))
                        {
                            GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().AttachJank.GetComponent<JankBase_iwata>().RotJank(-1, 0, GM.JointStage.Find("Core"));
                        }
                        break;
                        
                }
                break;

            case GameManager.eGameStatus.E_GAME_STATUS_ROT:
                //Bボタン
                if (PadInput.GetKeyDown(KeyCode.JoystickButton1))
                {
                    GM.GameStatus = GameManager.eGameStatus.E_GAME_STATUS_JOINT;
                }

                //Xボタン
                if (PadInput.GetKeyDown(KeyCode.JoystickButton2))
                {
                    GM.GameStatus = GameManager.eGameStatus.E_GAME_STATUS_PLAY;
                }

                //Lボタン
                if(PadInput.GetKey(KeyCode.JoystickButton4))
                {
                    GM.PlayStage.Find("Core(Clone)").GetComponent<Core_Playing>().RotL = true;
                }

                //Rボタン
                if (PadInput.GetKey(KeyCode.JoystickButton5))
                {
                    GM.PlayStage.Find("Core(Clone)").GetComponent<Core_Playing>().RotR = true;
                }
                break;
                
            case GameManager.eGameStatus.E_GAME_STATUS_PLAY:
                //Xボタン
                if (PadInput.GetKeyDown(KeyCode.JoystickButton2))
                {
                    GM.GameStatus = GameManager.eGameStatus.E_GAME_STATUS_ROT;
                }
                break;
        }
    }
}
