using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankStatus : ObjectBase
{
    [System.Serializable]
    public struct AttachFlag
    {
        public bool m_plusZ;
        public bool m_minusZ;
        public bool m_plusX;
        public bool m_minusX;
        public bool m_plusY;
        public bool m_minusY;
    }

    [Tooltip("もうついている時に使うフラグ")]
    [SerializeField] AttachFlag m_colliderFlags;    //もうついている時に使うフラグ

    [Tooltip("今から付ける時に使うフラグ")]
    [SerializeField] AttachFlag m_collisionFlags;     //今から付ける時に使うフラグ

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
    }

    /// <summary>
    /// 設置済みのオブジェクトの組み立てれる面かの判定
    /// </summary>
    public bool CanColliderFlags(Transform core)
    {
        //--- 組み立てられる面を全て洗い出す
        List<Vector3> attachVector = GetAttachVector();

        core.Rotate(0.0f, -10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す

        //--- 組み立てられる面かを判定する
        for (int i = 0; i < attachVector.Count; i++)
        {
            if (Vector3.Distance(attachVector[i], Vector3.forward) > 0.5f) continue;

            core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す
            return true;
        }

        core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す
        return false;
    }

    /// <summary>
    /// 仮置きのオブジェクトの組み立てれる面かの判定
    /// </summary>
    public bool CanCollisionFlags(Transform core)
    {
        //--- 組み立てられる面を全て洗い出す
        List<Vector3> attachVector = GetRotVector();
        
        core.Rotate(0.0f, -10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す
        //--- 組み立てられる面かを判定する
        for (int i = 0; i < attachVector.Count; i++)
        {
            if (Vector3.Distance(attachVector[i], Vector3.forward) > 0.5f) continue;

            core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す
            return true;
        }

        core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //コアの傾きを一時的に0，0，0に戻す
        return false;
    }

    /// <summary>
    /// 組み立てられる面を取得
    /// </summary>
    /// <returns></returns>
    public List<Vector3> GetAttachVector()
    {
        //--- 組み立てられる面を全て洗い出す
        List<Vector3> attachVector = new List<Vector3>();
        if (m_colliderFlags.m_plusZ)    attachVector.Add(this.transform.forward);
        if (m_colliderFlags.m_minusY)   attachVector.Add(-this.transform.forward);
        if (m_colliderFlags.m_plusX)    attachVector.Add(this.transform.right);
        if (m_colliderFlags.m_minusX)   attachVector.Add(-this.transform.right);
        if (m_colliderFlags.m_plusY)    attachVector.Add(this.transform.up);
        if (m_colliderFlags.m_minusY)   attachVector.Add(-this.transform.up);

        return attachVector;
    }

    public List<Vector3> GetRotVector()
    {
        //--- 組み立てられる面を全て洗い出す
        List<Vector3> rotVector = new List<Vector3>();
        if (m_collisionFlags.m_plusZ)    rotVector.Add(this.transform.forward);
        if (m_collisionFlags.m_minusY)   rotVector.Add(-this.transform.forward);
        if (m_collisionFlags.m_plusX)    rotVector.Add(this.transform.right);
        if (m_collisionFlags.m_minusX)   rotVector.Add(-this.transform.right);
        if (m_collisionFlags.m_plusY)    rotVector.Add(this.transform.up);
        if (m_collisionFlags.m_minusY)   rotVector.Add(-this.transform.up);

        return rotVector;
    }
}
