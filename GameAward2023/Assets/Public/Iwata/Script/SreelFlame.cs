using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SreelFlame : JankBase_iwata
{
    public int value = 5;   //UŒ‚‚µ‚½‚Æ‚«‚Ì•Ç‚ÉŠ|‚¯‚é”{—¦
    FixedJoint joint;
    
    /// <summary>
    /// “Sœ‚Ì“®‚«
    /// </summary>
    public override void work()
    {

    }

    public override List<float> GetParameterList()
    {
        List<float> list = new List<float>();

        return list;
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
