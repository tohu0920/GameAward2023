using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownJank_iwata : MonoBehaviour
{
    [SerializeField] Vector3 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
    }

    public void RemoveCore()
    {
        Destroy(this.GetComponent<FixedJoint>());
        this.transform.parent = GameObject.Find("Jank").transform;
        this.GetComponent<Rigidbody>().constraints &= RigidbodyConstraints.None;
        this.transform.position = StartPos;
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void ReturnJank()
    {
        this.GetComponent<Rigidbody>().constraints &= RigidbodyConstraints.None;
        this.transform.position = StartPos;
    }
}
