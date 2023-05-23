using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmController : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;
    [SerializeField] AudioManager.BGMKind bgm;

    private void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
        AudioManager.GetComponent<AudioManager>().PlayBGM(bgm);
    }
}