using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 別のスクリプトからエフェクトを再生する例
public class OtherScript : MonoBehaviour
{
    [SerializeField]
    private Manager effectManager;

    private void Start()
    {
        // エフェクト番号 0 を再生する
        effectManager.PlayEffect(0);

        effectManager.PlayEffect(1);
        effectManager.PlayEffect(2);
    }
}
