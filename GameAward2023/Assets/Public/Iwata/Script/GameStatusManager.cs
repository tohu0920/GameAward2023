using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        m_GameStatus = eGameStatus.E_GAME_STATUS_JOINT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public eGameStatus GameStatus
    {
        get { return m_GameStatus; }
        set { m_GameStatus = value; }
    }

}
