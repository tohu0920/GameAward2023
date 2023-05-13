using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalArea : MonoBehaviour
{
    private GameManager m_GameManager;

    // Start is called before the first frame update
    void Start()
    {
        // GameManager‚ð’T‚·
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Core") || other.transform.CompareTag("Player"))
        {
            m_GameManager.GameStatus = GameManager.eGameStatus.E_GAME_STATUS_END;
        }
    }
}