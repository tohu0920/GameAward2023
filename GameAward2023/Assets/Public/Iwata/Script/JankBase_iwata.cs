using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JankBase_iwata : JankStatus
{
    [SerializeField] Vector3 m_StartPos;      //開始時のポジション
    [SerializeField] Quaternion m_StartRot;      //開始時の回転
    [SerializeField] GameObject m_Origin;     //クローンなら元のオブジェクトを入れるよう

    /// <summary>
    /// 各ジャンク特有の処理を行う
    /// </summary>
    public abstract void work();

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        m_StartPos = transform.position;      //初期座標を登録
        m_StartRot = transform.rotation;      //初期回転を登録
    }

    ///<summary>
    ///ガラクタをガラクタ山に戻す時のガラクタの処理
    ///</summary>
    public void ReturnJank()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.transform.position = m_StartPos;
        this.transform.rotation = m_StartRot;
    }

    /// <summary>
    /// ガラクタをコアにつける時のガラクタの処理
    /// </summary>
    /// <param name="trans">　つけるコアのトランスフォーム　</param>
    public void JointJank(Transform trans)
    {
        this.transform.parent = null;       //親の登録を解除

        this.transform.rotation = Quaternion.identity;      //回転を初期化

        Transform CoreTrans = trans.parent;     //コアの大元を取得
        CoreTrans.Rotate(0.0f, -10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す
        this.transform.parent = CoreTrans;      //コアを親として登録する

        Vector3 pos = trans.transform.position;     //付ける面の座標取得
        pos.z -= trans.localScale.z / 2.0f;     //付ける面の大きさの半分ずらす
        pos.z -= this.transform.localScale.z / 2.0f;        //自分の半分ずらす
        this.transform.position = pos;      //ずらして決めた座標に移動する

        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;        //力が加わっても移動回転しないように固定

        CoreTrans.Rotate(0.0f, 10.0f, 0.0f, Space.World);       //一時的に0，0，0にしていた回転を戻す

        FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();      //FixrdJointを追加
        joint.connectedBody = trans.GetComponent<Rigidbody>();      //conenectedBodyにつけた面を登録
    }

    /// <summary>
    /// 仮置きしたガラクタの処理
    /// </summary>
    /// <param name="trans">選択面の情報</param>
    public void SetJank(Transform trans)
    {
        Transform CoreTrans = trans.parent;     //コアの大元を取得

        this.transform.rotation = Quaternion.identity;      //回転を初期化

        PutJank(trans, CoreTrans);

        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;        //力が加わっても移動回転しないように固定
        
    }

    public void PutJank(Transform trans, Transform core)
    {
        core.Rotate(0.0f, -10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す
        this.transform.parent = null;
        Vector3 pos = trans.transform.position;     //付ける面の座標取得
        pos.z -= trans.localScale.z / 2.0f;     //付ける面の大きさの半分ずらす
        pos.z -= this.transform.localScale.z / 2.0f;        //自分の半分ずらす
        this.transform.position = pos;      //ずらして決めた座標に移動する
        this.transform.parent = core;
        core.Rotate(0.0f, 10.0f, 0.0f, Space.World);       //一時的に0，0，0にしていた回転を戻す
    }

    public GameObject Orizin
    {
        get { return m_Origin; }
        set { m_Origin = value; }
    }
}
