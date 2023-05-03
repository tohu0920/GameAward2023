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
                            // 判定用のレイを用意
                            Ray ray = CursorController.GetCameraToRay(GM.JointStage.Find("JointCamera").gameObject);
                            RaycastHit hit;

                            //カーソルから奥に向けてレイを飛ばす
                            if (Physics.Raycast(ray, out hit))
                            {
                                // ガラクタではないならスルー
                                if (hit.transform.tag != "Jank" && hit.transform.tag != "Player") return;

                                //ジャンクコントローラーに今選択しているジャンクを登録
                                GM.JointStage.Find("Jank").GetComponent<JankController>().SelectJank = hit.collider.gameObject;

                                GameObject clone = Instantiate(hit.collider.gameObject);
                                clone.GetComponent<JankBase_iwata>().Orizin = hit.collider.gameObject;
                                GM.JointStage.GetComponent<JointStageManager>().JSStatus = JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_PUT;
                                GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().PutJank(clone);
                            }
                        }

                        ////Bボタン
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
