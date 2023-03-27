using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBlockWallObject : MonoBehaviour
{
    public GameObject BlockWallObject;
    public Vector3 Size = Vector3.one;

    public void Export()
    {
        Vector3 pos = this.transform.position;

        foreach(Transform child in this.transform)
        {
            DestroyImmediate(child.gameObject);
        }

        for(int z = 0; z < Size.z; z++)
        {
            for(int y = 0; y < Size.y; y++)
            {
                for(int x = 0; x < Size.x; x++)
                {
                    GameObject obj = Instantiate(BlockWallObject, pos, Quaternion.identity);
                    obj.transform.parent = this.transform;
                    pos.x += BlockWallObject.transform.localScale.x;
                }
                pos.x = this.transform.position.x;
                pos.y += BlockWallObject.transform.localScale.y;
            }
            pos.y = this.transform.position.y;
            pos.z += BlockWallObject.transform.localScale.z;
        }
    }
}
