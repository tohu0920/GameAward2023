using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    const float ROT_Y = 90.0f;  // 回転角度
    const float ROT_X = 90.0f;  // 回転角度

    //[SerializeReference] GameController m_gameController;   // ゲームの状態に関する情報を取得
    [SerializeReference] float m_dampingRate;   // 減衰率
    int m_timeToRotate;     // 回転に必要なフレーム数
    int m_rotFrameCnt;      // 回転時のフレームカウント
    float m_rotx,m_rotY, m_lateXZ; // 回転パラメータ
    Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rotFrameCnt = -1;
        m_rotY = m_lateXZ = 0.0f;
        m_timeToRotate = (int)(Mathf.Log(0.01f) / Mathf.Log(1.0f - m_dampingRate));
        m_rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_gameController.IsStart) return;

        // 遅延処理
        m_lateXZ = (m_rotY - m_lateXZ) * m_dampingRate + m_lateXZ;

        // 座標計算
        transform.eulerAngles = new Vector3(0.0f, m_lateXZ, 0.0f);

        if (m_rotFrameCnt < 0) return;

        m_rotFrameCnt++;    // 回転中のフレームカウント
    }

    /// <summary>
    /// コアの回転開始
    /// </summary>
    public void RotateCoreY(int direction)
    {

        m_rotY += ROT_Y * direction;

        m_rotFrameCnt = 0;
    }

    public void RotateCoreX(int direction)
    {

        //m_rotX += ROT_X * direction;

        m_rotFrameCnt = 0;
    }

    /// <summary>
    /// 部品をアタッチ出来る面を取得
    /// </summary>
    public List<Transform> GetAttachFace()
    {
        List<Transform> attachFace = new List<Transform>();

        // 子オブジェクトを順番に配列に格納
        foreach (Transform child in this.transform)
        {
            Ray ray = new Ray(child.position, Vector3.back);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit, 10.0f))
                attachFace.Add(child);
        }

        //--- ソート
        attachFace.Sort((a, b) => {
            if (a.position.y != b.position.y)
            {
                // Y 座標が異なる場合は Y 座標で比較する
                return b.position.y.CompareTo(a.position.y);
            }
            else
            {
                // Y 座標が同じ場合は X 座標で比較する
                return a.position.x.CompareTo(b.position.x);
            }
        });

        return attachFace;
    }

    /// <summary>
    /// 回転終了フラグ
    /// </summary>
    public bool IsRotEnd()
    {
        if (m_rotFrameCnt > m_timeToRotate)
        {
            m_rotFrameCnt = -1; // カウントのリセット
            return true;
        }

        return false;
    }

    /// <summary>
    /// 部品をアタッチする
    /// </summary>
    public void AttachParts(Transform face, GameObject prefabParts)
    {
        Vector3 pos = face.position + (Vector3.forward.normalized * -1.0f);
        GameObject parts = Instantiate(prefabParts, pos, Quaternion.identity);

        parts.transform.SetParent(this.transform);
    }

    /// <summary>
    /// 座標・回転のFreezeを解く
    /// </summary>
    public void UnlockFreeze()
    {
        // スタート地点へ移動
        this.transform.position = new Vector3(-10.0f, 2.5f, -10.0f);
        this.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        m_rigidbody.constraints = RigidbodyConstraints.None;    // 物理演算をスタート

       // m_gameController.IsStart = true;
    }

    //public bool IsStart
    //{
    //    get { return m_gameController.IsStart; }
    //}
}