using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankStatus : ObjectBase
{
    [SerializeField] private Vector3 m_orizinSize;
    [SerializeField] private Vector3 m_pickupSize;
    [SerializeField] private static float m_val = 1.25f;

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        m_orizinSize = this.transform.localScale;
        m_pickupSize = m_orizinSize * m_val;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 OrizinSize
    {
        get { return m_orizinSize; }
    }

    public void PickupSize()
    {
        this.transform.localScale = m_pickupSize;
    }
    public void UndoSize()
    {
        this.transform.localScale = m_orizinSize;
    }
}
