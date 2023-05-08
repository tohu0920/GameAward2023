using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacitor_iwata : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.name != "Core(Clone)") return;

        switch(collision.transform.GetComponent<JankStatus>().JankTag)
        {
            case JankStatus.eJankTag.E_JANK_TAG_CORE:
                Transform core = collision.transform.parent;
                core.GetComponent<Core_Playing>().DestroyCore();
                break;
            case JankStatus.eJankTag.E_JANK_TAG_METAL:
                break;
        }
    }
}
