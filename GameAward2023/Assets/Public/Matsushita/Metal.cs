using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : junkBase
{
    /// <summary>
    /// 蓄電器に当たったとき
    /// </summary>
    public override void HitCapacitor()
    {
        Debug.Log("ゲームオーバー");
    }   
}
