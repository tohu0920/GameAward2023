using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JankBase : JankStatus
{
    [SerializeField] Vector3 StartPos;      //開始時のポジション
    [SerializeField] Quaternion StartRot;      //開始時のポジション

    public abstract void work();

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        StartPos = transform.position;
        StartRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///<summary>
    ///ガラクタをガラクタ山に戻す時のガラクタの処理
    ///</summary>
    public void ReturnJank()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.transform.position = StartPos;
        this.transform.rotation = StartRot;
    }

    /// <summary>
    /// ガラクタをコアにつける時のガラクタの処理
    /// </summary>
    /// <param name="trans">　つけるコアのトランスフォーム　</param>
    public void JointJank(Transform trans)
    {
        this.transform.parent = null;

        this.transform.rotation = Quaternion.identity;

        Transform CoreTrans = trans.parent;
        CoreTrans.Rotate(-10.0f, 0.0f, 0.0f, Space.World);
        this.transform.parent = CoreTrans;

        Transform ChildTrans = CoreTrans.Find(trans.name);
        Vector3 pos = ChildTrans.transform.position;
        Debug.Log(pos);
        pos.z -= ChildTrans.localScale.z / 2.0f;
        pos.z -= this.transform.localScale.z / 2.0f;
        this.transform.position = pos;

        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        CoreTrans.Rotate(10.0f, 0.0f, 0.0f, Space.World);

        FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = trans.GetComponent<Rigidbody>();
    }
}
