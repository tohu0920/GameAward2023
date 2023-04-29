using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Metal
{

    [SerializeReference] float m_boostForceRate;
    [SerializeReference] float m_maxSpeed;

    // Start is called before the first frame update
    void Start()
    {

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
    /// <summary>
    /// 蓄電器にあたったとき
    /// </summary>
    public override void HitCapacitor()
    {
    }
}
