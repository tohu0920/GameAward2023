using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose_iwata : MonoBehaviour
{
    public enum ePoseKind
    {
        E_POSE_KIND_NULL = 0,
        E_POSE_KIND_STAGESELECT,
        E_POSE_KIND_OPTION,
        E_POSE_KIND_EXIT,

        E_POSE_KIND_MAX
    }

    [SerializeField] PoseSwitch StageSelect;
    [SerializeField] PoseSwitch Option;
    [SerializeField] PoseSwitch BuckTitle;

    [SerializeField] ePoseKind m_PoseKind;
    int m_Input;
    //bool m_A;

    // Start is called before the first frame update
    void Start()
    {
        m_PoseKind = ePoseKind.E_POSE_KIND_STAGESELECT;
        m_Input = 0;
        StageSelect.Flag = true;
        Option.Flag = false;
        BuckTitle.Flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_Input += AxisInput.GetAxisRawRepeat("Vertical_L");
        m_Input += AxisInput.GetAxisRawRepeat("Vertical_PadX");
        if (PadInput.GetKeyDown(KeyCode.JoystickButton0))
        {
            switch (m_PoseKind)
            {
                case ePoseKind.E_POSE_KIND_STAGESELECT:
                    StageSelect.GoNextCanvas();
                    break;
                case ePoseKind.E_POSE_KIND_OPTION:
                    Option.GoNextCanvas();
                    break;
                case ePoseKind.E_POSE_KIND_EXIT:
                    BuckTitle.GoNextCanvas();
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        bool flag = false;

        if(m_Input > 0)
        {
            flag = true;
            m_PoseKind--;
            if (m_PoseKind == ePoseKind.E_POSE_KIND_NULL) m_PoseKind = ePoseKind.E_POSE_KIND_EXIT;
        }
        else if(m_Input < 0)
        {
            flag = true;
            m_PoseKind++;
            if (m_PoseKind == ePoseKind.E_POSE_KIND_MAX) m_PoseKind = ePoseKind.E_POSE_KIND_STAGESELECT;
        }

        if(flag)
        {
            switch (m_PoseKind)
            {
                case ePoseKind.E_POSE_KIND_STAGESELECT:
                    StageSelect.Flag = true;
                    Option.Flag = false;
                    BuckTitle.Flag = false;
                    break;
                case ePoseKind.E_POSE_KIND_OPTION:
                    StageSelect.Flag = false;
                    Option.Flag = true;
                    BuckTitle.Flag = false;
                    break;
                case ePoseKind.E_POSE_KIND_EXIT:
                    StageSelect.Flag = false;
                    Option.Flag = false;
                    BuckTitle.Flag = true;
                    break;
            }
        }

        m_Input = 0;
    }
}
