using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_Playing : ObjectBase
{
    [SerializeField] GameManager gm;
    [SerializeField] static Quaternion startRot;
    static bool start = false;
    bool m_Life;
    bool m_RotL = false;
    bool m_RotR = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        start = true;
        m_Life = true;
    }

    private void FixedUpdate()
    {
        switch(gm.GameStatus)
        {
            case GameManager.eGameStatus.E_GAME_STATUS_ROT:
                if(m_RotL)
                {
                    transform.Rotate(0.0f, -2.0f, 0.0f, Space.World);
                    m_RotL = false;
                }
                if(m_RotR)
                {
                    transform.Rotate(0.0f, 2.0f, 0.0f, Space.World);
                    m_RotR = false;
                }
                break;
            case GameManager.eGameStatus.E_GAME_STATUS_PLAY:
                // 子オブジェクトからParentクラスを継承したスクリプトを取得する
                JankBase_iwata[] scripts = GetComponentsInChildren<JankBase_iwata>();

                // 取得したスクリプトのwork関数を実行する
                foreach (JankBase_iwata script in scripts)
                {
                    script.work();
                }
                break;
        }

        Transform boxTransform = transform.Find("Core_Child0");
        Vector3 cornerOffset = new Vector3(0.5f, -0.5f, 0.5f);
        Vector3 cornerPosition;
        cornerPosition = boxTransform.position + cornerOffset;
        transform.Find("CoreCenter").position = cornerPosition;
    }

    /// <summary>
    /// コアを破壊して爆発させる
    /// </summary>
    public void DestroyCore()
    {
        if (!m_Life) return;

        float explosionForce = 20.0f; // 爆発力
        float explosionRadius = 5.0f; // 爆発半径
        Vector3 explosionPosition = transform.Find("CoreCenter").position;

        foreach (Transform child in this.transform)
        {
            FixedJoint[] fixedJoints = child.GetComponents<FixedJoint>();
            Rigidbody[] rb = child.GetComponents<Rigidbody>();

            foreach(FixedJoint joint in fixedJoints)
            {
                Destroy(joint);
            }

            foreach(Rigidbody childrb in rb)
            {
                childrb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 0.0f, ForceMode.Impulse);
            }
        }
        
        EffectMane.PlayEffect(EffectType.E_EFFECT_KIND_EXPLOSION, explosionPosition, this.transform);

        m_Life = false;
    }

    public void DamageCore(Transform target)
    {
        if (!m_Life) return;

        float explosionForce = 50.0f; // 爆発力
        float explosionRadius = 30.0f; // 爆発半径
        Vector3 explosionPosition = target.position;
        explosionPosition.y += 0.5f;

        Destroy(target.GetComponent<FixedJoint>());

        foreach (Transform child in this.transform)
        {
            Rigidbody[] rb = child.GetComponents<Rigidbody>();
            
            foreach (Rigidbody childrb in rb)
            {
                childrb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 0.0f, ForceMode.Impulse);
            }
        }
        
        EffectMane.PlayEffect(EffectType.E_EFFECT_KIND_EXPLOSION, explosionPosition, this.transform);
    }

    public void ResetPlayCore()
    {
        startRot = Quaternion.identity;
        start = false;
        m_Life = true;
    }

    public bool StartFlag
    {
        set { start = value; }
        get { return start; }
    }

    public Quaternion StartRot
    {
        set { startRot = value; }
        get { return startRot; }
    }

    public bool RotL
    {
        set { m_RotL = value; }
    }

    public bool RotR
    {
        set { m_RotR = value; }
    }

    public bool Life
    {
        get { return m_Life; }
    }

}
