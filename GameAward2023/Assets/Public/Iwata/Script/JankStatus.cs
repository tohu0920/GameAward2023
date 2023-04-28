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

    // Update is called once per frame
    void Update()
    {
        
    }
}
