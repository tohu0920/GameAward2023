using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float Speed = 3.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            force += Vector3.left * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force += Vector3.right * Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            force += Vector3.forward * Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            force += Vector3.back * Speed;
        }

        rb.AddForce(force);

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.down, 1.0f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, 1.0f);
        }
    }
}
