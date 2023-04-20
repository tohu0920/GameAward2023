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

    [SerializeField] private GameObject m_PlayStage;        //プレイ用の環境
    [SerializeField] private GameObject m_JointStage;       //組み立て用の環境
    [SerializeField] private Dictionary<string, GameObject> m_Objects = new Dictionary<string, GameObject>();   //今実行している環境で扱えるオブジェクトを登録

    [SerializeField] private eGameStatus m_GameStatus;  //ゲームの状態

    // Start is called before the first frame update
    void Start()
    {
        m_GameStatus = eGameStatus.E_GAME_STATUS_JOINT;     //ゲームの状態の初期化

        //アクティブの環境のオブジェクトの情報を登録
        foreach (Transform childTransform in m_JointStage.transform)
        {
            GameObject childObject = childTransform.gameObject;
            string objectName = childObject.name;

            // Dictionaryに登録する
            m_Objects[objectName] = childObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject PlayStage
    {
        get { return m_PlayStage; }
    }

    public GameObject JointStage
    {
        get { return m_JointStage; }
    }

    public Dictionary<string, GameObject> Objects
    {
        get { return m_Objects; }
    }

    public eGameStatus GameStatus
    {
        get { return m_GameStatus; }
        set { m_GameStatus = value; }
    }
}
