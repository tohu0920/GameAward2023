using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewJank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttachPreviewJank(GameObject obj)
    {
        Debug.Log(obj.transform.name);

        Vector3 pos = this.transform.position;
        pos.z += this.transform.localScale.z / 2.0f;
        pos.z += obj.transform.localScale.z / 2.0f;

        obj.transform.position = pos;

        obj.transform.rotation = new Quaternion();

        obj.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
