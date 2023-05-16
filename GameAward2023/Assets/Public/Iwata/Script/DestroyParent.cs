using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    Transform parent;

    private void Awake()
    {
        if(!parent)
        {
            parent = GameObject.Find("PlayStage").transform.Find("StageObject").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.GetComponent<FixedJoint>())
        {
            this.gameObject.transform.parent = parent;
            // Rigidbodyコンポーネントを取得
            Rigidbody rb = GetComponent<Rigidbody>();

            // Rigidbodyのconstraintsプロパティを取得して、x軸、y軸、z軸のFreezePositionフラグをfalseに設定
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            rb.constraints &= ~RigidbodyConstraints.FreezeRotationX;
            rb.constraints &= ~RigidbodyConstraints.FreezeRotationY;
            rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
