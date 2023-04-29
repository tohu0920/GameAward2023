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

        //this.transform.parent = trans.parent;

        //this.transform.rotation = this.transform.parent.transform.rotation;

        //float targetheaf = trans.localScale.z / 2.0f;
        //float thisheaf = this.transform.localScale.z / 2.0f;

        //Vector3 pos = trans.localPosition;

        //pos.z = pos.z - targetheaf - thisheaf;

        //this.transform.localPosition = pos;

        FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = trans.GetComponent<Rigidbody>();
    }
}
