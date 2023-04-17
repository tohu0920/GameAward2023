using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJetPower : MonoBehaviour
{
    public float Power;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector3(Power, 0.0f, 0.0f));
    }
}
