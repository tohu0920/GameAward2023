using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum BGMKind
    {
        E_BGM_KIND_TITLE = 0,
        E_BGM_KIND_STAGE1,
        E_BGM_KIND_MAX
    }
    public enum SEKind
    {
        E_SE_KIND_SELECT = 0,
        E_SE_KIND_HOGE,
        E_SE_KIND_MAX
    }

    public static AudioManager instance;

    [SerializeField] private AudioClip[] bgms = new AudioClip[(int)BGMKind.E_BGM_KIND_MAX];
    [SerializeField] private AudioClip[] ses = new AudioClip[(int)SEKind.E_SE_KIND_MAX];
    [SerializeField] private float bgmVolume = 1.0f;
    [SerializeField] private float seVolume = 1.0f;
    private AudioSource bgmSource;
    private AudioSource[] seSource = new AudioSource[(int)SEKind.E_SE_KIND_MAX];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;

        for (int i = 0; i < ses.Length; i++)
        {
            if (ses[i] == null) continue;
            seSource[i] = gameObject.AddComponent<AudioSource>();
            seSource[i].volume = seVolume;
            seSource[i].clip = ses[i];
        }
    }

    public void PlayBGM(BGMKind index)
    {
        bgmSource.clip = bgms[(int)index];
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PlaySE(SEKind index)
    {
        seSource[(int)index].Play();
    }

    public float BGMvolume
    {
        get { return bgmVolume; }
        set { bgmVolume = value; bgmSource.volume = bgmVolume; }
    }

    public float SEvolume
    {
        get { return seVolume; }
        set { seVolume = value; for (int i = 0; i < ses.Length; i++) { seSource[i].volume = seVolume; } }
    }
}