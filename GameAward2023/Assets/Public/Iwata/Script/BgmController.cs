using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmController : MonoBehaviour
{
    public BgmController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] AudioManager.BGMKind bgm;

    private void Start()
    {
        AudioManager.PlayBGM(bgm);
    }

    private void OnEnable()
    {
        // シーン遷移時のコールバックを登録
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // シーン遷移時のコールバックを解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーン遷移時の処理をここに記述
        if (scene.name == "")
        {
            // 特定のオブジェクトを持ち越す処理など
        }
    }
}