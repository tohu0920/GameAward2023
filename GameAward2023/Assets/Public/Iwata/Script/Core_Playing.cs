using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_Playing : MonoBehaviour
{
    [SerializeField] GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(gm.GameStatus == GameManager.eGameStatus.E_GAME_STATUS_PLAY)
        {
            // 子オブジェクトからParentクラスを継承したスクリプトを取得する
            JankBase[] scripts = GetComponentsInChildren<JankBase>();

            // 取得したスクリプトのwork関数を実行する
            foreach (JankBase script in scripts)
            {
                script.work();
            }
        }

    }
}
