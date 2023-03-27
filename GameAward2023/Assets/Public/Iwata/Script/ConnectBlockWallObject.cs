using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectBlockWallObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FixedJoint[] hoge = new FixedJoint[2];
        hoge[0] = this.gameObject.AddComponent<FixedJoint>();
        hoge[1] = this.gameObject.AddComponent<FixedJoint>();

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        Ray ray = new Ray(this.transform.position, Vector3.right);
        RaycastHit hit;
        float length = (this.transform.localScale.x / 2) + 0.1f;
        Physics.Raycast(ray, out hit, length);
        hoge[0].connectedBody = hit.rigidbody;

        ray = new Ray(this.transform.position, Vector3.up);
        //RaycastHit hit;
        length = (this.transform.localScale.y / 2) + 0.1f;
        Physics.Raycast(ray, out hit, length);
        hoge[1].connectedBody = hit.rigidbody;

        hoge[0].breakForce = hoge[1].breakForce = 10;
        hoge[0].breakTorque = hoge[1].breakTorque = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
