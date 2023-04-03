using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBlockWallObject : MonoBehaviour
{
    //並べるプレハブ
    public GameObject BlockWallObject;
    //並べる数
    public Vector3Int Size = Vector3Int.one;
    //BreakForceの設定数値
    public float Endure = 10;

    // 生成されたオブジェクトを保持する配列
    private GameObject[,,] blocks;


    public void Export()
    {
        //ブロックの生成情報を保持するための変数を初期化
        blocks = new GameObject[Size.x + 1, Size.y + 1, Size.z + 1];
        //オブジェクトを配置するPosを初期化
        Vector3 pos = this.transform.position;

        //子オブジェクトが既にあればすべて削除する
        while (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            DestroyImmediate(child.gameObject);
        }

        //生成して配置していく
        for (int z = 0; z < Size.z; z++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    //生成
                    blocks[x, y, z] = Instantiate(BlockWallObject, pos, Quaternion.identity);
                    //親の設定
                    blocks[x, y, z].transform.parent = this.transform;
                    pos.x += BlockWallObject.transform.localScale.x;
                }
                pos.x = this.transform.position.x;
                pos.y += BlockWallObject.transform.localScale.y;
            }
            pos.y = this.transform.position.y;
            pos.z += BlockWallObject.transform.localScale.z;
        }

        //ConnectedBodyの設定
        FixedJoint[] hoge = new FixedJoint[3];
        for (int z = 0; z < Size.z; z++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    //FixedJointの追加
                    hoge[0] = blocks[x, y, z].AddComponent<FixedJoint>();
                    hoge[1] = blocks[x, y, z].AddComponent<FixedJoint>();
                    hoge[2] = blocks[x, y, z].AddComponent<FixedJoint>();

                    for(int i = 0; i < 3; i++)
                    {
                        hoge[i].connectedBody = null;
                    }

                    //ConnectedBodyの設定
                    if (blocks[x + 1, y, z] != null)
                        hoge[0].connectedBody = blocks[x + 1, y, z].GetComponent<Rigidbody>();
                    if (blocks[x, y + 1, z] != null)
                        hoge[1].connectedBody = blocks[x, y + 1, z].GetComponent<Rigidbody>();
                    if (blocks[x, y, z + 1] != null)
                        hoge[2].connectedBody = blocks[x, y, z + 1].GetComponent<Rigidbody>();

                    //breakForceの設定
                    hoge[0].breakForce = hoge[1].breakForce = hoge[2].breakForce = Endure;
                    hoge[0].breakTorque = hoge[1].breakTorque = hoge[2].breakTorque = Endure;

                    //不要なFixedJointを削除する
                    for(int i = 0; i < 3; i++)
                    {
                        if(hoge[i].connectedBody == null)
                        {
                            DestroyImmediate(hoge[i]);
                        }
                    }
                }
            }
        }
    }
}
