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

    [Tooltip("�����Ă��鎞�Ɏg���t���O")]
    [SerializeField] AttachFlag m_colliderFlags;    //�����Ă��鎞�Ɏg���t���O

    [Tooltip("������t���鎞�Ɏg���t���O")]
    [SerializeField] AttachFlag m_collisionFlags;     //������t���鎞�Ɏg���t���O

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
