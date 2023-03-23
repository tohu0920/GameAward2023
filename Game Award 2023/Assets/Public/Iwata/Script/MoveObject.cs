using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // public Rigidbody rigidbody;
    public float Speed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
        if(Input.GetKey(KeyCode.A))
        {
            velocity.x -= Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= Speed;
        }
        GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, velocity.y, velocity.z);

        Vector3 angle = transform.eulerAngles;
        if (Input.GetKey(KeyCode.E))
        {
            angle.y -= 0.1f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            angle.y += 0.1f;
        }
        transform.eulerAngles = angle;
    }
}
