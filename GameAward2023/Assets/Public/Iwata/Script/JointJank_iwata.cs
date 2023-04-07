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

    }

    public void JointJanktoCore(Transform trans)
    {
       
        
        this.transform.parent = null;
        this.transform.parent = trans.parent;

        Vector3 pos = trans.position;
        pos.z -= trans.localScale.z / 2.0f;
        pos.z -= this.transform.localScale.z / 2.0f;
        this.transform.position = pos;


        FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = trans.GetComponent<Rigidbody>();
    }
}
