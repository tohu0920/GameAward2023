using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseSwitch : MonoBehaviour
{
    [SerializeField] GameObject myCanvas;

    Transform m_True;
    Transform m_False;
    bool m_flag;

    private void Start()
    {
        m_True = transform.GetChild(1);
        m_False = transform.GetChild(0);
        myCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(m_flag)
        {
            m_True.gameObject.SetActive(true);
            m_False.gameObject.SetActive(false);
        }
        else
        {
            m_True.gameObject.SetActive(false);
            m_False.gameObject.SetActive(true);
        }
    }

    public void GoNextCanvas()
    {
        transform.parent.gameObject.SetActive(false);
        myCanvas.SetActive(true);
    }

    public bool Flag
    {
        set { m_flag = value; }
    }

}
