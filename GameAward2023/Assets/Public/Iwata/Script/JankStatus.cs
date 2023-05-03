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

    [Tooltip("ï¿½ï¿½ï¿½Â‚ï¿½ï¿½Ä‚ï¿½ï¿½éï¿½Égï¿½ï¿½ï¿½tï¿½ï¿½ï¿½O")]
    [SerializeField] AttachFlag m_colliderFlags;    //ï¿½ï¿½ï¿½Â‚ï¿½ï¿½Ä‚ï¿½ï¿½éï¿½Égï¿½ï¿½ï¿½tï¿½ï¿½ï¿½O

    [Tooltip("ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½tï¿½ï¿½ï¿½éï¿½Égï¿½ï¿½ï¿½tï¿½ï¿½ï¿½O")]
    [SerializeField] AttachFlag m_collisionFlags;     //ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½tï¿½ï¿½ï¿½éï¿½Égï¿½ï¿½ï¿½tï¿½ï¿½ï¿½O

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
    }

    /// <summary>
    /// İ’uÏ‚İ‚ÌƒIƒuƒWƒFƒNƒg‚Ì‘g‚İ—§‚Ä‚ê‚é–Ê‚©‚Ì”»’è
    /// </summary>
    public bool CanColliderFlags(Transform core)
    {
        //--- ‘g‚İ—§‚Ä‚ç‚ê‚é–Ê‚ğ‘S‚Äô‚¢o‚·
        List<Vector3> attachVector = GetAttachVector();

        core.Rotate(0.0f, -10.0f, 0.0f, Space.World);      //ƒRƒA‚ÌŒX‚«‚ğˆê“I‚É0C0C0‚É–ß‚·

        //--- ‘g‚İ—§‚Ä‚ç‚ê‚é–Ê‚©‚ğ”»’è‚·‚é
        for (int i = 0; i < attachVector.Count; i++)
        {
            if (Vector3.Distance(attachVector[i], Vector3.forward) > 0.5f) continue;

            core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //ƒRƒA‚ÌŒX‚«‚ğˆê“I‚É0C0C0‚É–ß‚·
            return true;
        }

        core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //ƒRƒA‚ÌŒX‚«‚ğˆê“I‚É0C0C0‚É–ß‚·
        return false;
    }

    /// <summary>
    /// ‰¼’u‚«‚ÌƒIƒuƒWƒFƒNƒg‚Ì‘g‚İ—§‚Ä‚ê‚é–Ê‚©‚Ì”»’è
    /// </summary>
    public bool CanCollisionFlags(Transform core)
    {
        //--- ‘g‚İ—§‚Ä‚ç‚ê‚é–Ê‚ğ‘S‚Äô‚¢o‚·
        List<Vector3> attachVector = GetRotVector();
        
        core.Rotate(0.0f, -10.0f, 0.0f, Space.World);      //ƒRƒA‚ÌŒX‚«‚ğˆê“I‚É0C0C0‚É–ß‚·
        //--- ‘g‚İ—§‚Ä‚ç‚ê‚é–Ê‚©‚ğ”»’è‚·‚é
        for (int i = 0; i < attachVector.Count; i++)
        {
            if (Vector3.Distance(attachVector[i], Vector3.forward) > 0.5f) continue;

            core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //ƒRƒA‚ÌŒX‚«‚ğˆê“I‚É0C0C0‚É–ß‚·
            return true;
        }

        core.Rotate(0.0f, 10.0f, 0.0f, Space.World);      //ƒRƒA‚ÌŒX‚«‚ğˆê“I‚É0C0C0‚É–ß‚·
        return false;
    }

    /// <summary>
    /// ‘g‚İ—§‚Ä‚ç‚ê‚é–Ê‚ğæ“¾
    /// </summary>
    /// <returns></returns>
    public List<Vector3> GetAttachVector()
    {
        //--- ‘g‚İ—§‚Ä‚ç‚ê‚é–Ê‚ğ‘S‚Äô‚¢o‚·
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
        //--- ‘g‚İ—§‚Ä‚ç‚ê‚é–Ê‚ğ‘S‚Äô‚¢o‚·
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
