using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutHierarchy : MonoBehaviour
{
    [SerializeReference] GameSceneController gSC;
    private GameObject core;
    private HashSet<Transform> Junks;
    private bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        isStart = gSC.IsStart;
        if (isStart)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
                Junks.Add(transform.GetChild(i));
            isStart = false;
            SearchJunks(Junks);
            // Hierarchy上でCoreから外れる
            foreach (Transform obj in Junks)
                obj.transform.parent = null;
        }
    }

    /// <summary>
    /// ガラクタを経路探索で探すための関数
    /// </summary>
    private void SearchJunks(HashSet<Transform> Junks)
    {
        // 探索済みガラクタを格納
        HashSet<Transform> searchedJunks = new HashSet<Transform>();
        HashSet<Transform> connectToCoreJunks = new HashSet<Transform>();

        // 経路上のガラクタを一時敵に格納
        HashSet<Transform> junks = new HashSet<Transform>();

        FixedJoint[] fixedJoints = Junks.First().GetComponents<FixedJoint>();

        // 周辺のガラクタを1つずつ調べる
        foreach (FixedJoint fixedJoint in fixedJoints)
        {
            // 結合されているガラクタを取得
            Transform connectJunk = fixedJoint.connectedBody.transform;

            // 探索済みであれば処理しない
            if (searchedJunks.Contains(connectJunk)) continue;

            // 探索対象がコアなら処理しない
            if (connectJunk.tag == "Core") continue;

            // 経路上にあるオブジェクトを格納
            junks.Add(connectJunk);

            // コアに行きあたるまで探索
            if (SearchJunksLoop(Junks.First(), connectJunk, junks, connectToCoreJunks))
            {
                //--- コアまでの経路をリストに追加
                foreach (Transform junk in junks)
                    connectToCoreJunks.Add(junk);

                junks.Clear();  // コアまで繋がっていればリストを削除
                continue;
            }

            //--- コアに繋がらない経路をリストに追加
            foreach (Transform junk in junks)
                Junks.Add(junk);

            junks.Clear();  // 一時的なリストを削除
        }

        // 削除対象のガラクタも追加
        Junks.Add(Junks.First());
    }

    /// <summary>
    /// ガラクタを再帰的に探すための関数
    /// </summary>
    private bool SearchJunksLoop(Transform selectJunk, Transform junk, HashSet<Transform> searchJunks, HashSet<Transform> connectToCoreJunks)
    {
        // 探索対象のFixedJointを取得
        FixedJoint[] fixedJoints = junk.GetComponents<FixedJoint>();

        foreach (FixedJoint fixedJoint in fixedJoints)
        {
            // 結合されているガラクタを取得
            Transform connectJunk = fixedJoint.connectedBody.transform;

            // 探索済みであれば処理しない
            if (searchJunks.Contains(connectJunk)) continue;

            // 削除対象のガラクタは処理しない
            if (connectJunk == selectJunk) continue;

            // コアに繋がる経路に繋がっていれば探索を終了
            if (connectToCoreJunks.Contains(connectJunk)) return true;

            // 探索対象がコアなら探索を終了
            if (connectJunk.tag == "Core") return true;

            // 経路上にあるオブジェクトを格納
            searchJunks.Add(connectJunk);

            // コアに行きあたるまで再帰的に探索
            if (SearchJunksLoop(selectJunk, connectJunk, searchJunks, connectToCoreJunks)) return true;
        }
        return false;
    }

}
