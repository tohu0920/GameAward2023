using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float WIND_FORCE = 10.0f; // 風の強さ
    public float WIND_RANGE = 5.0f; // 風の範囲
    public float DISTANCE_ATTENUATION = 1.0f; // 距離による減衰率
    public float WIDTH = 5.0f; // 風を発生させる面の幅
    public float HEIGHT = 5.0f; // 風を発生させる面の高さ
    public Transform windSurface; // 風を発生させる面のTransform

    void Update()
    {
        // 風を発生させる位置を計算する
        Vector3 windPos = windSurface.position + windSurface.forward * WIND_RANGE;

        // 範囲内のオブジェクトに風の力を加える
        Collider[] colliders = Physics.OverlapBox(windPos, new Vector3(WIDTH / 2, HEIGHT / 2, WIND_RANGE));
        foreach (Collider col in colliders)
        {
            // 接触したオブジェクトにRigidbodyがアタッチされている場合
            Rigidbody rb = col.GetComponent<Rigidbody>();

            // Player,Core,Junkのタグを持っている場合
            if (rb != null /*|| col.CompareTag("Player") || col.CompareTag("Core") || CompareTag("Junk")*/)
            {
                // 風の力を計算してRigidbodyに加える
                Vector3 force = GetWindForce(rb.position) * Time.deltaTime;
                rb.AddForce(force, ForceMode.Force);
            }
        }
    }

    // 風の影響を与える範囲を表示する
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        // 範囲を表示する
        Gizmos.DrawWireCube(windSurface.position + windSurface.forward * WIND_RANGE, new Vector3(WIDTH, HEIGHT, WIND_RANGE));
    }

    // 風の力を計算するメソッド
    Vector3 GetWindForce(Vector3 pos)
    {
        // 風が吹く面の法線を計算する
        Vector3 normal = -windSurface.forward;

        float distance = Vector3.Distance(windSurface.position, pos); // 接触オブジェクトとの距離を計算する

        // 風の強さを距離に応じて減衰させる
        float attenuation = Mathf.Clamp01(1.0f - distance / WIND_RANGE) * DISTANCE_ATTENUATION;
        // 風の力を計算する
        Vector3 force = normal * WIND_FORCE * attenuation;

        return force;
    }
}
