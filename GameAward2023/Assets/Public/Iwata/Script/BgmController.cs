using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmController : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;

    private void Start()
    {
        AudioManager.GetComponent<AudioManager>().PlayBGM(0);
    }
}