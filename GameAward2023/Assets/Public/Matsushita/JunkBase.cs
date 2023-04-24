using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBase : MonoBehaviour
{
    void Start()
    {
    }


    /// <summary>
    /// 釘コンクリートにあたったとき
    /// </summary>
    public virtual void HitNailConcrete()
    {
    }

    /// <summary>
    /// 蓄電器にあたったとき
    /// </summary>
    public virtual void HitCapacitor()
    {
    }

    /// <summary>
    /// 燃えているドラム缶にあたったとき
    /// </summary>
    public virtual void HitFireDrum()
    {

    }

    public virtual void Explosion()
    {
        Explosion explosion = transform.root.gameObject.GetComponent<Explosion>();
        if (explosion == null) return;

        explosion.Blast();
    }

}
