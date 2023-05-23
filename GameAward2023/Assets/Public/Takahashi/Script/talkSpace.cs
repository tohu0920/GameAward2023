using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkSpace : MonoBehaviour
{
    [SerializeField] private CursorController_araki m_cursor;
    [SerializeField] private ReadJson m_json;
    [SerializeField] private PreviewCamera_araki m_previewCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string name;
        switch (m_cursor.state)
        {
            case E_RAY_HIT_STATE.STAY:
                if (!m_previewCamera.isEndNoise)
                    break;
                name = m_cursor.SelectJank.name;
                m_json.DisplayText(name);
                break;

            case E_RAY_HIT_STATE.EXIT:
                m_json.ClearText();
                break;
            default:
                break;
        }
    }   
}
