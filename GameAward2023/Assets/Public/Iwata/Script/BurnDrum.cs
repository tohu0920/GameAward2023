using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnDrum : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1");
        if (collision.transform.parent.name != "Core(Clone)") return;
        Debug.Log("2");
        if (collision.transform.GetComponent<Drum>().JankTag != JankStatus.eJankTag.E_JANK_TAG_DRUM) return;
        Debug.Log("3");

        float explosionForce = 50.0f; // ”š”­—Í
        float explosionRadius = 30.0f; // ”š”­”¼Œa

        Destroy(collision.transform.GetComponent<FixedJoint>());
        Rigidbody rb = collision.rigidbody;
        rb.AddExplosionForce(explosionForce, collision.transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
        EffectManager_iwata.PlayEffect(EffectType.E_EFFECT_KIND_EXPLOSION, collision.transform.position, this.transform);
    }
}
