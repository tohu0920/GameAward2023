using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailVariant : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.name != "Core(Clone)") return;

        Transform core = collision.transform.parent;

        core.GetComponent<Core_Playing>().DestroyCore();
    }
}
