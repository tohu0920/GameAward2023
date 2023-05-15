using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float scale = 1.0f;

    private void Update()
    {
        var main = particleSystem.main;
        main.startSize = scale;
    }
}
