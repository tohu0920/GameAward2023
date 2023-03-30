using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBooster : JunkBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Rigidbody rigidbody = this.transform.GetComponent<Rigidbody>();
		float currentSpeed = rigidbody.velocity.magnitude;

		if (currentSpeed < 5.0f)	rigidbody.AddForce(this.transform.forward.normalized * 50.0f);
	}
}