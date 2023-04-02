using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBlockWallObject : MonoBehaviour
{
    public GameObject BlockWallObject;
    public Vector3 Size = Vector3.one;
    public float Endure = 10;

    public void Export()
    {
        Vector3 pos = this.transform.position;

        while (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            DestroyImmediate(child.gameObject);
        }

        for (int z = 0; z < Size.z; z++)
        {
            for(int y = 0; y < Size.y; y++)
            {
                for(int x = 0; x < Size.x; x++)
                {
                    GameObject obj = Instantiate(BlockWallObject, pos, Quaternion.identity);
                    obj.transform.parent = this.transform;
                    pos.x += BlockWallObject.transform.localScale.x;

                    FixedJoint[] hoge = new FixedJoint[2];
                    hoge[0] = obj.AddComponent<FixedJoint>();
                    hoge[1] = obj.AddComponent<FixedJoint>();

                    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //RaycastHit hit;
                    Ray ray = new Ray(obj.transform.position, Vector3.right);
                    RaycastHit hit;
                    float length = (obj.transform.localScale.x / 2) + 0.1f;
                    Physics.Raycast(ray, out hit, length);
                    //Debug.Log(hit.transform.name);
                    hoge[0].connectedBody = hit.rigidbody;

                    ray = new Ray(obj.transform.position, Vector3.up);
                    //RaycastHit hit;
                    length = (obj.transform.localScale.y / 2) + 0.1f;
                    Physics.Raycast(ray, out hit, length);
                    hoge[1].connectedBody = hit.rigidbody;

                    hoge[0].breakForce = hoge[1].breakForce = Endure;
                    hoge[0].breakTorque = hoge[1].breakTorque = Endure;
                }
                pos.x = this.transform.position.x;
                pos.y += BlockWallObject.transform.localScale.y;
            }
            pos.y = this.transform.position.y;
            pos.z += BlockWallObject.transform.localScale.z;
        }
    }
}
