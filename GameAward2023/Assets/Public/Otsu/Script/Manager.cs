using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // エフェクトのデータを保持するためのクラス
    [System.Serializable]
    public class EffectData
    {
        public GameObject effectPrefab; // エフェクトのプレハブ
        public float duration; // エフェクトの再生時間
    }

    [SerializeField]
    private List<EffectData> effects = new List<EffectData>(); // エフェクトのリスト
    private GameObject currentEffect; // 現在再生中のエフェクト

    // エフェクトを再生するためのメソッド
    public void PlayEffect(int index)
    {
        if (currentEffect != null)
        {
            Destroy(currentEffect); // 現在再生中のエフェクトを破棄する
        }

        // 指定されたエフェクトを生成し、再生時間後に破棄する
        currentEffect = Instantiate(effects[index].effectPrefab, transform.position, Quaternion.identity);
        Destroy(currentEffect, effects[index].duration);
    }
}

