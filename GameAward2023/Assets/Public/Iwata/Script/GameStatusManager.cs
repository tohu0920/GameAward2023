using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField] GameObject Core;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject Canvas;

    public enum eGameStatus
    {
        E_GAME_STATUS_START = 0,
        E_GAME_STATUS_JOINT,
        E_GAME_STATUS_ROT,
        E_GAME_STATUS_PLAY,
        E_GAME_STATUS_POUSE,
        E_GAME_STATUS_END,

        E_GAME_STATUS_MAX
    }

    [SerializeField] static eGameStatus m_GameStatus;
    eGameStatus m_lastGameStatus;

    // Start is called before the first frame update
    void Start()
    {
        m_GameStatus = eGameStatus.E_GAME_STATUS_JOINT;
        m_lastGameStatus = m_GameStatus;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_GameStatus != m_lastGameStatus)
        {
            switch (m_lastGameStatus)
            {
                case eGameStatus.E_GAME_STATUS_JOINT:
                    switch (m_GameStatus)
                    {
                        case eGameStatus.E_GAME_STATUS_ROT:
                            Core.GetComponent<CoreSetting_iwata>().JointToRot();
                            Camera.transform.Find("Main Camera").gameObject.SetActive(false);
                            Camera.transform.Find("PlayCamera").gameObject.SetActive(true);
                            Canvas.transform.Find("Cursor").gameObject.SetActive(false);
                            break;
                    }

                    break;

                case eGameStatus.E_GAME_STATUS_ROT:
                    switch (m_GameStatus)
                    {
                        case eGameStatus.E_GAME_STATUS_JOINT:
                            Core.GetComponent<CoreSetting_iwata>().RotToJoint();
                            Camera.transform.Find("PlayCamera").gameObject.SetActive(false);
                            Camera.transform.Find("Main Camera").gameObject.SetActive(true);
                            Canvas.transform.Find("Cursor").gameObject.SetActive(true);
                            break;
                        case eGameStatus.E_GAME_STATUS_PLAY:
                            Core.GetComponent<CoreSetting_iwata>().RotToPlay();
                            break;
                    }
                break;
                case eGameStatus.E_GAME_STATUS_PLAY:
                    switch (m_GameStatus)
                    {
                        case eGameStatus.E_GAME_STATUS_JOINT:
                            Core.GetComponent<CoreSetting_iwata>().PlayToRot();
                            Camera.transform.Find("PlayCamera").gameObject.SetActive(false);
                            Camera.transform.Find("Main Camera").gameObject.SetActive(true);
                            Canvas.transform.Find("Cursor").gameObject.SetActive(true);
                            break;
                    }
                    break;


            }




            m_lastGameStatus = m_GameStatus;
        }

        
    }

    public eGameStatus GameStatus
    {
        get { return m_GameStatus; }
        set { m_GameStatus = value; }
    }

}
