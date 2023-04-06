using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPositionChanges : MonoBehaviour
{
    private Vector3 lastPosition;

    private void Start()
    {
        // 初期位置を保存
        lastPosition = transform.position;
    }

    private void Update()
    {
        // 位置が変更された場合
        if (transform.position != lastPosition)
        {
            // 変更前と変更後の位置をログ出力
            Debug.Log("Position changed from " + lastPosition + " to " + transform.position);

            // どのスクリプトのどの関数で変更されたかをログ出力
            Debug.Log("Changed by " + UnityEngine.StackTraceUtility.ExtractStackTrace());

            // 位置を更新
            lastPosition = transform.position;
        }
    }
}
