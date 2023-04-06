using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointJank_iwata : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<FixedJoint>())
        {
            Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

            // オブジェクトに加えられる力とトルクを取得する
            Vector3 force = rb.mass * rb.velocity;
            //Vector3 torque = rb.inertiaTensor * rb.angularVelocity;

            // 取得した力とトルクをログに出力する
            Debug.Log("Force on object: " + force);
            //Debug.Log("Torque on object: " + torque);

            //Debug.Log(this.transform.position);
        }
    }

    public void JointJanktoCore(Transform trans)
    {
        FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = trans.GetComponent<Rigidbody>();

        this.transform.parent = trans.parent;

        Vector3 pos = trans.position;
        pos.z -= trans.localScale.z / 2.0f;
        pos.z -= this.transform.localScale.z / 2.0f;
        this.transform.position = pos;
    }
}
