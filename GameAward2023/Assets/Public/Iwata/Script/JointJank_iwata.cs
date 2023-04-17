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

        //Vector3 pos = trans.localPosition;
        //pos.z -= trans.localScale.z / 2.0f;
        //pos.z -= this.transform.localScale.z / 2.0f;
        //this.transform.localPosition = pos;

        //Debug.Log(trans.name);


        this.transform.rotation = this.transform.parent.transform.rotation;

        float targetheaf = trans.localScale.z / 2.0f;
        float thisheaf = this.transform.localScale.z / 2.0f;

        //Debug.Log("target:" + targetheaf);
        //Debug.Log("this:" + thisheaf);

        Vector3 pos = trans.localPosition;

        //Debug.Log("pos:" + pos);

        pos.z = pos.z - targetheaf - thisheaf;

        //Debug.Log(pos.z - targetheaf - thisheaf);

        Debug.Log(pos);

        this.transform.localPosition = pos;

        //Debug.Log(this.transform.localPosition);

        FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = trans.GetComponent<Rigidbody>();
    }
}
