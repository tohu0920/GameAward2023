using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NailConcrate : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Core"))
        {
            JunkBase junkBase = col.gameObject.GetComponent<JunkBase>();
            if (junkBase != null)
            {
                junkBase.HitNailConcrete();
            }
        }
    }
}
