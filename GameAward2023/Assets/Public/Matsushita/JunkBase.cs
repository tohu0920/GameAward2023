using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBase : MonoBehaviour
{
    public Explosion explosionReference;

    void Start()
    {
        explosionReference = FindObjectOfType<Explosion>();
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Danger"))
        {
            Explosion();
        }
    }

    /// <summary>
    /// 釘コンクリートにあたったとき
    /// </summary>
    public virtual void HitNailConcrete()
    {
        Debug.Log("釘コンクリートにあたった！");
    }

    /// <summary>
    /// 蓄電器にあたったとき
    /// </summary>
    public virtual void HitCapacitor()
    {
        Debug.Log("蓄電器にあたった！");
    }

    public virtual void Explosion()
    {
        explosionReference.Blast();
    }

}
