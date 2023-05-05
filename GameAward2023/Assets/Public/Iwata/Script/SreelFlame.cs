using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SreelFlame : JankBase_iwata
{
    public int value = 5;
    FixedJoint joint;
    
    /// <summary>
    /// ìSçúÇÃìÆÇ´
    /// </summary>
    public override void work()
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
