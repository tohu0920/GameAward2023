using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_iwata : MonoBehaviour
{
    public GameObject Core;
    public GameObject Preview;
    public GameObject Jank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //十字ボタン
        if(Core.GetComponent<CoreSetting_iwata>().m_rotateFrameCnt <= 0)
        {
            float axisX = AxisInput.GetAxisRawRepeat("Horizontal");
            float axisY = (float)AxisInput.GetAxisRawRepeat("Vertical");
            if (axisX != 0)
                Core.GetComponent<CoreSetting_iwata>().ChangeFaceX(axisX);
            else if (axisY != 0)
                Core.GetComponent<CoreSetting_iwata>().ChangeFaceY(axisY);
        }

        //Aボタン
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            //--- プレビューが有効でない場合のみ選択可能
            if (!Preview.activeSelf)
            {
                // 判定用のレイを用意
                Ray ray = CursorController.GetCameraToRay();
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.tag);

                    // ガラクタではないならスルー
                    if (hit.transform.tag != "Jank" && hit.transform.tag != "Player") return;

                    // プレビューを有効化
                    Preview.SetActive(true);
                    Preview.transform.Find("PreviewBase").GetComponent<PreviewJank>().AttachPreviewJank(hit.collider.gameObject);

                    Jank.GetComponent<JankController>().SelectJank = hit.collider.gameObject;

                    //m_seController.PlaySe("Select");
                }
            }
            else
            {
                bool AttachSuccess = false;
               
                
                AttachSuccess = Core.GetComponent<CoreSetting_iwata>().AttachCore(Jank.GetComponent<JankController>().SelectJank);
                
                
                Preview.SetActive(false);
            }
        }

        //Bボタン
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Core.GetComponent<CoreSetting_iwata>().ReleaseCore();
        }

    }
}
