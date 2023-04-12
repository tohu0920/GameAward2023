using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankAttack : MonoBehaviour
{
    public int value = 5;
    FixedJoint joint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            joint = collision.transform.GetComponent<FixedJoint>();

            joint.breakForce /= value;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            joint.breakForce *= value;
        }
    }
}
