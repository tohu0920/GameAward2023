using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;
    private bool switchCamera; 

    void Start()
    {
        // 最初はサブカメラを非表示にする
        subCamera.enabled = false;
    }

    void Update()
    {
        // Vキーが押されたらサブカメラの表示を切り替える
        switchCamera = Input.GetMouseButtonDown(0);
        if (switchCamera)
        {
            switchCamera &= subCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
        }
    }
    
    public bool OffPrevCamera()
    {
        return switchCamera; 
    }
}
