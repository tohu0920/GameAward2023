using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster_Matusita : Metal
{

    [SerializeReference] float m_boostForceRate;
    [SerializeReference] float m_maxSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// パラメーター配置
    /// </summary>
    /// <param name="paramList"></param>
    public override void SetParam(List<float> paramList)
    {
        m_boostForceRate = paramList[0];
        m_maxSpeed = paramList[1];
    }

    // Update is called once per frame
    void Update()
    {
        //--- 現在のスピードを取得
        Rigidbody rigidbody = this.transform.GetComponent<Rigidbody>();
        float currentSpeed = rigidbody.velocity.magnitude;

        // ブースト用のベクトルを計算
        Vector3 boostFoce = this.transform.forward.normalized * m_boostForceRate;

        // 最大速度以下の時のみ処理する
        if (currentSpeed < m_maxSpeed) rigidbody.AddForce(boostFoce);   // ブースト処理
    }
    /// <summary>
    /// 釘コンクリートにあたったとき
    /// </summary>
    public override void HitNailConcrete()
    {

    }
}
