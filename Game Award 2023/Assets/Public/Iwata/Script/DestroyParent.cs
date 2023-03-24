using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.GetComponent<FixedJoint>())
        {
            this.gameObject.transform.parent = null;
        }
    }
}
