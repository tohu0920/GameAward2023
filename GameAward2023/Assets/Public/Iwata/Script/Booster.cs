using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] GameObject GSManager;
    [SerializeField] GameObject EffectManager;
    [SerializeReference] float m_boostForceRate;
    [SerializeReference] float m_maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        EffectManager = GameObject.Find("EffectManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(GSManager.transform.GetComponent<GameStatusManager>().GameStatus == GameStatusManager.eGameStatus.E_GAME_STATUS_PLAY)
        {
            if (!this.transform.parent.name.Contains("Core")) return;

            //--- 現在のスピードを取得
            Rigidbody rigidbody = this.transform.GetComponent<Rigidbody>();
            float currentSpeed = rigidbody.velocity.magnitude;

            // ブースト用のベクトルを計算
            Vector3 boostFoce = this.transform.forward.normalized * m_boostForceRate;

            // 最大速度以下の時のみ処理する
            if (currentSpeed < m_maxSpeed) rigidbody.AddForce(boostFoce);	// ブースト処理

            EffectManager.GetComponent<EffectManager_iwata>().PlayEffect(EffectType.E_EFFECT_KIND_JET, this.transform.position);
        }
    }
}
