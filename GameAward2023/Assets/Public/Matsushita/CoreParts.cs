using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreParts : Metal
{
    /// <summary>
    /// 釘コンクリートにあたったとき
    /// </summary>
    public override void HitNailConcrete()
    {
        Debug.Log("ゲームオーバー");
    }

    /// <summary>
    /// ゴールに触れたとき
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("ゲームクリア");
        }
    }

}
