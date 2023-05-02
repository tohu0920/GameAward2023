using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpring : Metal
{
    public float maxHeight = 2f; // シリンダーの最大高さ
    public float minHeight = 0.5f; // シリンダーの最小高さ
    public float increasingSpeed = 3f; // 伸縮速度（伸びるとき）
    public float decreasingSpeed = 1f; // 伸縮速度（縮むとき）

    private float currentHeight; // 現在の高さ
    private bool increasing = true; // 増加中かどうかを表すフラグ

    /// <summary>
    /// パラメーター配置
    /// </summary>
    /// <param name="paramList"></param>
    public override void SetParam(List<float> paramList)
    {
        maxHeight = paramList[0];
        minHeight = paramList[1];
        increasingSpeed = paramList[2];
        decreasingSpeed = paramList[3];
    }


    private void Start()
    {
        currentHeight = minHeight; // 初期値を設定
    }

    private void Update()
    {
        // 高さを変更
        if (increasing)
        {
            currentHeight += increasingSpeed * Time.deltaTime; // 増加中
        }
        else
        {
            currentHeight -= decreasingSpeed * Time.deltaTime; // 減少中
        }

        // 最大高さに達した場合、増加中のフラグを反転させる
        if (currentHeight >= maxHeight)
        {
            increasing = false;
        }
        // 最小高さに達した場合、増加中のフラグを反転させる
        else if (currentHeight <= minHeight)
        {
            increasing = true;
        }

        // シリンダーのスケールを変更する
        transform.localScale = new Vector3(1f, currentHeight, 1f);
    }
}