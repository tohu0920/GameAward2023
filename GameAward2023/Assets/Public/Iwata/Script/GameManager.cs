using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ゲームの状態のフラグ
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

    [SerializeField] private StageManagerBase m_PlayStage;        //プレイ用の環境
    [SerializeField] private StageManagerBase m_JointStage;       //組み立て用の環境

    [SerializeField] private eGameStatus m_GameStatus;  //ゲームの状態

    // Start is called before the first frame update
    void Start()
    {
        m_GameStatus = eGameStatus.E_GAME_STATUS_JOINT;     //ゲームの状態の初期化
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public StageManagerBase PlayStage
    {
        get { return m_PlayStage; }
    }

    public StageManagerBase JointStage
    {
        get { return m_JointStage; }
    }


    public eGameStatus GameStatus
    {
        get { return m_GameStatus; }
        set { m_GameStatus = value; }
    }
}
