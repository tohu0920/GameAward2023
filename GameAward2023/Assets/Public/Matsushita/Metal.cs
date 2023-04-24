using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : JunkBase
{
    /// <summary>
    /// ’~“dŠí‚É“–‚½‚Á‚½‚Æ‚«
    /// </summary>
    public override void HitCapacitor()
    {
        JunkBase junkBase = GetComponent<JunkBase>();

        if (junkBase != null)
        {
            junkBase.Explosion();
        }
    }
}