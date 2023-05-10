using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    [SerializeField] public static AudioManager AudioMane;
    [SerializeField] public static EffectManager_iwata EffectMane;

    // Start is called before the first frame update
    public static void Start()
    {
        AudioMane = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        EffectMane = GameObject.Find("EffectManager").GetComponent<EffectManager_iwata>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
