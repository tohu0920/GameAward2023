using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponObject : MonoBehaviour
{
    public float pos;
    private Vector3 ResponPos;

    // Start is called before the first frame update
    void Start()
    {
        ResponPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= pos)
        {
            transform.position = ResponPos;
        }
    }
}
