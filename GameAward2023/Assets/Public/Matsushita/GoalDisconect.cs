using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDisconect : MonoBehaviour
{ 
    void Update()
    {
        if (GameManager.Instance.GameStatus != GameManager.eGameStatus.E_GAME_STATUS_END)
            return;

        // "fixjoint"でつながっているオブジェクトを取得
        FixedJoint[] joints = FindObjectsOfType<FixedJoint>();

        foreach (FixedJoint joint in joints)
        {
            // 接続されたオブジェクトのタグが"Player"でなければ切断する
            if (joint.connectedBody.gameObject.tag != "Player")
            {
                Destroy(joint);
            }
        }
    }
}