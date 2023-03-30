using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void AttachJunk(GameObject junk)
	{
		Vector3 newPos = this.transform.position;
		newPos -= this.transform.forward;

		junk.GetComponent<Rigidbody>().isKinematic = true;
		junk.transform.position = newPos;			// 座標の指定
		junk.transform.rotation = new Quaternion(); // 角度の指定
		junk.transform.SetParent(this.transform.root);
	}
}