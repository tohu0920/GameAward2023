using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jettsize : MonoBehaviour
{
     ParticleSystem particleSystem;
     float lifeTime = 1.0f;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        var main = particleSystem.main;
        main.startLifetime = lifeTime;//ジェットが消えてなくなる速さ
    }
    public float LifeTime
    {
        set { lifeTime = value; }
    }
}
