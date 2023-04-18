using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    E_EFFECT_KIND_JET = 0,
    E_EFFECT_KIND_MAX
}

[System.Serializable]
public class EffectInfo
{
    public EffectType type;
    public GameObject effectPrefab;
}


public class EffectManager_iwata : MonoBehaviour
{


    public List<EffectInfo> effectList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(EffectType type, Vector3 position)
    {
        EffectInfo effectInfo = effectList.Find(effect => effect.type == type);

        if (effectInfo != null)
        {
            GameObject effectInstance = Instantiate(effectInfo.effectPrefab, position, Quaternion.identity);
            // エフェクトを再生するための追加の処理をここに記述することができます。
        }
        else
        {
            Debug.LogWarning("No effect of type " + type + " was found.");
        }
    }
}
