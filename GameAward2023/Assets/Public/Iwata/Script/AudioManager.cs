using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip[] bgms;
    [SerializeField] private AudioClip[] ses;
    [SerializeField] private float bgmVolume = 0.5f;
    [SerializeField] private float seVolume = 0.5f;
    private AudioSource bgmSource;
    private AudioSource seSource;

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

        seSource = gameObject.AddComponent<AudioSource>();
        seSource.volume = seVolume;
    }

    public void PlayBGM(int index)
    {
        if (index < 0 || index >= bgms.Length) return;

        bgmSource.clip = bgms[index];
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PlaySE(int index)
    {
        if (index < 0 || index >= ses.Length) return;

        seSource.PlayOneShot(ses[index]);
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        bgmSource.volume = bgmVolume;
    }

    public void SetSEVolume(float volume)
    {
        seVolume = volume;
        seSource.volume = seVolume;
    }
}