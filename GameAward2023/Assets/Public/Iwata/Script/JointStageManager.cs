using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointStageManager : MonoBehaviour
{
    public enum eJointStageStatus
    {
        E_JOINTSTAGE_STATUS_SELECT = 0,
        E_JOINTSTAGE_STATUS_PUT,
        E_JOINTSTAGE_STATUS_JOINT,

        E_JOINTSTAGE_STATUS_MAX
        
    }

    [SerializeField] private eJointStageStatus m_JSStatus;

    // Start is called before the first frame update
    void Start()
    {
        m_JSStatus = eJointStageStatus.E_JOINTSTAGE_STATUS_SELECT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public eJointStageStatus JSStatus
    {
        get { return m_JSStatus; }
        set { m_JSStatus = value; }
    }

}
