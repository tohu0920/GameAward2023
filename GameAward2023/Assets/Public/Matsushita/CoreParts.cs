using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CoreParts : Metal
{
    private FixedJoint fixedJoint;
    private int frameCount = 0;
    private const int MAX_FRAME_COUNT = 60; // 1秒あたりのフレーム数が60の場合

    void Start()
    {
        fixedJoint = GetComponent<FixedJoint>();
    }

    void Update()
    {
        // FixedJointが削除された場合の処理
        if (fixedJoint == null)
        {
            frameCount++;

            // １秒経過したらゲームシーンに移動
            if (frameCount > MAX_FRAME_COUNT)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        else
        {
            frameCount = 0;
        }
    }

    /// <summary>
    /// 釘コンクリートにあたったとき
    /// </summary>
    public override void HitNailConcrete()
    {
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
