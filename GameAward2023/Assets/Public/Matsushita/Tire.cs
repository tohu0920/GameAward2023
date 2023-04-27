using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : JunkBase
{
    [SerializeReference] float m_bounceRate;
    [SerializeField] private float explosionForce = 100f; // 爆発力
    [SerializeField] private float explosionRadius = 10f; // 爆発半径

    private void OnCollisionStay(Collision collision)   // 瞬間的に大きな力を加えるとタイヤが取れてしまう為
    {
        //--- 壁と衝突した時の処理
        if (collision.transform.tag == "Wall")
        {
            //--- 反発するベクトルを計算
            Vector3 vToSelf = this.transform.position - collision.contacts[0].point;
            vToSelf.y = 0.0f;   // Y軸方向への移動を無視
            vToSelf = vToSelf.normalized * m_bounceRate;

            // 反発するベクトルを適用
            this.GetComponent<Rigidbody>().AddForce(vToSelf, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// パラメーター配置
    /// </summary>
    /// <param name="paramList"></param>
    public override void SetParam(List<float> paramList)
    {
        m_bounceRate = paramList[0];
    }


    /// <summary>
    /// 釘コンクリートにあたったとき
    /// </summary>
    public override void HitNailConcrete()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 3.0F);
            }
        }

    }
}
