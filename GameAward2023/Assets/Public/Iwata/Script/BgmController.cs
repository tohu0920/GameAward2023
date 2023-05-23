using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmController : MonoBehaviour
{
    [SerializeField] AudioManager.BGMKind bgm;

    private void Start()
    {
        AudioManager.PlayBGM(bgm);
    }
}