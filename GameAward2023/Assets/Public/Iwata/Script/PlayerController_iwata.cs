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
                                GM.JointStage.GetComponent<JointStageManager>().JSStatus = JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_PUT;
                                GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().PutJank(clone);
                            }
                        }

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
                        break;

                    case JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_JOINT:
                        break;
                }




                ////十字ボタン
                //if (GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().m_rotateFrameCnt <= 0)
                //{
                //    int axisX = AxisInput.GetAxisRawRepeat("Horizontal_PadX");
                //    int axisY = AxisInput.GetAxisRawRepeat("Vertical_PadX");
                //    if(axisX != 0 || axisY != 0)
                //    {
                //        GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().InputAxisCore(axisX, axisY);
                //    }
                //}
                
                ////Aボタン
                //if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
                //{
                //    // 判定用のレイを用意
                //    Ray ray = CursorController.GetCameraToRay(GM.JointStage.Find("JointCamera").gameObject);
                //    RaycastHit hit;
                    
                //    //カーソルから奥に向けてレイを飛ばす
                //    if (Physics.Raycast(ray, out hit))
                //    {
                //        // ガラクタではないならスルー
                //        if (hit.transform.tag != "Jank" && hit.transform.tag != "Player") return;

                //        //ジャンクコントローラーに今選択しているジャンクを登録
                //        GM.JointStage.Find("Jank").GetComponent<JankController>().SelectJank = hit.collider.gameObject;

                //        GameObject clone = Instantiate(hit.collider.gameObject);
                //        GM.JointStage.GetComponent<JointStageManager>().JSStatus = JointStageManager.eJointStageStatus.E_JOINTSTAGE_STATUS_PUT;
                //        GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().PutJank(clone);
                //    }
                //}

                ////Bボタン
                //if (PadInput.GetKeyDown(KeyCode.JoystickButton1))
                //{
                //    if (!GM.JointStage.Find("Preview").gameObject.activeSelf)
                //    {
                //        GM.JointStage.Find("Core").GetComponent<CoreSetting_iwata>().ReleaseCore();
                //    }
                //    else
                //    {
                //        GM.JointStage.Find("Jank").GetComponent<JankController>().ReturnJank();
                //        GM.JointStage.Find("Preview").gameObject.SetActive(false);
                //    }
                //}


                //////Lボタン
                ////if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.Q))
                ////{
                ////    if (Preview.activeSelf)
                ////    {
                ////        Jank.GetComponent<JankController>().SelectJank.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
                ////    }
                ////}

                //////Rボタン
                ////if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.E))
                ////{
                ////    if (Preview.activeSelf)
                ////    {
                ////        Jank.GetComponent<JankController>().SelectJank.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                ////    }
                ////}

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
