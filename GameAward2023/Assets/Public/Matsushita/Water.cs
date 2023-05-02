using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float slowForce = 2f; // ゆっくりと動かすための力の大きさ
    public Vector3 areaSize = Vector3.one; // ゆっくりと動かすエリアの大きさ
    private Collider areaCollider; // ゆっくりと動かすエリアのコライダー

    /// <summary>
    /// パラメーター配置
    /// </summary>
    /// <param name="paramList"></param>
    public void SetParam(List<float> paramList)
    {
        slowForce = paramList[0];
        areaSize.x = paramList[1];
        areaSize.y = paramList[2];
        areaSize.z = paramList[3];
    }

    private void Start()
    {
        if (areaCollider == null)
        {
            areaCollider = GetComponent<Collider>();
            if (areaCollider == null)
            {
                areaCollider = gameObject.AddComponent<BoxCollider>();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // 範囲内の物体に対して速度を減速させる力を加える
        if (other.attachedRigidbody != null)
        {
            Debug.Log("スロー");
            Vector3 slowForceVector = -other.attachedRigidbody.velocity.normalized * slowForce;
            other.attachedRigidbody.AddForce(slowForceVector, ForceMode.Acceleration);
        }
    }

    private void OnDrawGizmos()
    {
        // エリアの範囲を表示する
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }

    private void OnValidate()
    {
        if (areaCollider == null)
        {
            areaCollider = GetComponent<Collider>();
            if (areaCollider == null)
            {
                areaCollider = gameObject.AddComponent<BoxCollider>();
            }
        }
    }
}
