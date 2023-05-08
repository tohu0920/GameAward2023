using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpring : JankBase_iwata
{
    public float waitTime = 2f; // 最小値に達した後の待機時間
    public float maxHeight = 2f; // シリンダーの最大高さ
    public float minHeight = 0.5f; // シリンダーの最小高さ
    public float increasingSpeed = 3f; // 伸縮速度（伸びるとき）
    public float decreasingSpeed = 1f; // 伸縮速度（縮むとき）

    private float currentHeight; // 現在の高さ
    private bool increasing = true; // 増加中かどうかを表すフラグ
    private bool waiting = false; // 待機中かどうかを表すフラグ
    private float timeSinceMinHeight = 0f; // 最小値に達してからの経過時間を保持する変数

    public override void work()
    {

    }

    /// <summary>
    /// パラメーター配置
    /// </summary>
    /// <param name="paramList"></param>
    public void SetParam(List<float> paramList)
    {
        waitTime = paramList[0];
    }


    private void Start()
    {
        currentHeight = minHeight; // 初期値を設定
    }

    private void Update()
    {
        // 高さを変更
        if (increasing && !waiting)
        {
            currentHeight += increasingSpeed * Time.deltaTime; // 増加中
        }
        else if (!increasing && !waiting)
        {
            currentHeight -= decreasingSpeed * Time.deltaTime; // 減少中
        }

        // 最大高さに達した場合、増加中のフラグを反転させる
        if (currentHeight >= maxHeight)
        {
            increasing = false;
        }
        // 最小高さに達した場合、増加中のフラグを反転させ、待機中のフラグを立てる
        else if (currentHeight <= minHeight)
        {
            increasing = true;
            waiting = true;
        }

        // 最小値に達した後、一定時間待機してから再び伸び始める
        if (waiting)
        {
            timeSinceMinHeight += Time.deltaTime;
            if (timeSinceMinHeight >= waitTime)
            {
                waiting = false;
                timeSinceMinHeight = 0f;
            }
        }

        // シリンダーのスケールを変更する
        transform.localScale = new Vector3(1f, currentHeight, 1f);
    }
}
