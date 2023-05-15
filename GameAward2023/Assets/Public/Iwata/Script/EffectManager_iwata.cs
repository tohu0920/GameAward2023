using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    E_EFFECT_KIND_JET = 0,
    E_EFFECT_KIND_EXPLOSION,
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
    
    public void PlayEffect(EffectType type, Vector3 position, Transform parent)
    {
        EffectInfo effectInfo = effectList.Find(effect => effect.type == type);

        if (effectInfo != null)
        {
            GameObject effectInstance = Instantiate(effectInfo.effectPrefab, position, Quaternion.identity);
            effectInstance.transform.parent = parent;
        }
        else
        {
            Debug.LogWarning("No effect of type " + type + " was found.");
        }
    }
}
