using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectObject
{
    public string name; // エフェクトの名前
    public GameObject effectPrefab; // プレハブとして設定したエフェクト
}

public class EffectManager : MonoBehaviour
{
    [SerializeField] private List<EffectObject> effectList; // エフェクトのリスト

    // エフェクトを再生する関数
    public void PlayEffect(string effectName, Vector3 position)
    {
        // エフェクト名と一致するエフェクトを検索
        EffectObject effectObject = effectList.Find(e => e.name == effectName);

        // エフェクトを再生
        if (effectObject != null)
        {
            GameObject effect = Instantiate(effectObject.effectPrefab, position, Quaternion.identity);
            Destroy(effect, 3f); // エフェクトの再生時間を指定する
        }
        else
        {
            Debug.LogWarning("Effect not found: " + effectName);
        }
    }
}
