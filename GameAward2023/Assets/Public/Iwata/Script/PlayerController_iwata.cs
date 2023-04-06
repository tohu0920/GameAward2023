using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_iwata : MonoBehaviour
{
    public GameObject Core;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Core.GetComponent<CoreSetting_iwata>().m_rotateFrameCnt <= 0)
        {
            float axisX = AxisInput.GetAxisRawRepeat("Horizontal");
            float axisY = (float)AxisInput.GetAxisRawRepeat("Vertical");
            if (axisX != 0)
                Core.GetComponent<CoreSetting_iwata>().ChangeFaceX(axisX);
            else if (axisY != 0)
                Core.GetComponent<CoreSetting_iwata>().ChangeFaceY(axisY);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            //--- プレビューが有効でない場合のみ選択可能
            if (!m_previewController.Active)
            {
                // 判定用のレイを用意
                Ray ray = CursorController.GetCameraToRay();
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // ガラクタではないならスルー
                    if (hit.transform.tag != "Junk") return;

                    // プレビューを有効化
                    m_previewController.Active = true;
                    m_previewController.TargetFace.AttachJunk(hit.transform.gameObject);

                    m_seController.PlaySe("Select");
                }
            }
        }

    }
}
