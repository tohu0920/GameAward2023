using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_Matusita : JankBase_iwata
{
    public float springForce = 300.0f; // 跳ね返りの強さ
    public float minDot = 0.9f; // 面衝突判定の閾値
    public float extraForce = 100.0f; //追加の力

    private BoxCollider boxCollider;

    public override void work()
    {

    }

    public override List<float> GetParam()
    {
        List<float> list = new List<float>();

        return list;
    }

    public override void SetParam(List<float> paramList)
    {

    }

    void Start()
    {
        // Box Colliderを取得
        boxCollider = GetComponent<BoxCollider>();
        // 当たり判定を有効化
        boxCollider.isTrigger = false;
    }

    //---------------------------------------------------
    /// <summary>
    /// パラメーター配置
    /// </summary>
    /// <param name="paramList"></param>
    //public override void SetParam(List<float> paramList)
    //{
    //}
    //-----------------------------

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがBox Colliderを持つ場合、各面での当たり判定を取得
        if (collision.gameObject.GetComponent<BoxCollider>())
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                // 衝突点の座標を取得
                Vector3 point = contact.point;

                // 立方体のローカル座標系に変換
                Vector3 localPoint = transform.InverseTransformPoint(point);

                // 各面の中心点からの距離を計算し、最小値を持つ面を当たった面として扱う
                float[] distances = new float[6];
                distances[0] = Mathf.Abs(localPoint.z - boxCollider.center.z + boxCollider.size.z / 2f);
                distances[1] = Mathf.Abs(localPoint.z - boxCollider.center.z - boxCollider.size.z / 2f);
                distances[2] = Mathf.Abs(localPoint.y - boxCollider.center.y + boxCollider.size.y / 2f);
                distances[3] = Mathf.Abs(localPoint.y - boxCollider.center.y - boxCollider.size.y / 2f);
                distances[4] = Mathf.Abs(localPoint.x - boxCollider.center.x + boxCollider.size.x / 2f);
                distances[5] = Mathf.Abs(localPoint.x - boxCollider.center.x - boxCollider.size.x / 2f);

                int minIndex = 0;
                float minDistance = distances[0];
                for (int i = 1; i < 6; i++)
                {
                    if (distances[i] < minDistance)
                    {
                        minDistance = distances[i];
                        minIndex = i;
                    }
                }
                if (minIndex == 2 || minIndex == 5)
                {
                    Debug.Log("Hit face: " + (minIndex + 1));

                    Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

                    // ぶつかった相手がRigidbodyを持っている場合、跳ね返す
                    if (rb != null)
                    {
                        Vector3 direction = collision.contacts[0].point - transform.position;
                        float dot = Vector3.Dot(direction.normalized, collision.contacts[0].normal);

                        // 面衝突判定を行う
                        if (-dot > minDot)
                        {
                            float force = (springForce + extraForce) * -dot; //追加の力を加える
                            rb.AddForce(direction.normalized * force, ForceMode.Force);
                            GetComponent<Rigidbody>().AddForce(-direction.normalized * force, ForceMode.Force);
                        }
                        else
                        {
                            float force = springForce * -dot;
                            rb.AddForce(direction.normalized * force, ForceMode.Force);
                            GetComponent<Rigidbody>().AddForce(-direction.normalized * force, ForceMode.Force);
                        }

                        // 当たった面の番号をログに出力
                        Debug.Log("あたった面: " + minIndex);
                    }
                }
            }
        }
    }
}

