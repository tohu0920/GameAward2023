using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundObject
{
    public string name; // サウンドの名前
    public AudioClip clip; // オーディオクリップ

    public void Play(AudioSource source)
    {
        source.clip = clip;
        source.Play();
    }
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<SoundObject> bgmList; // BGMのリスト
    [SerializeField] private List<SoundObject> seList; // SEのリスト

    // BGMを再生する関数
    public void PlayBGM(string bgmName, AudioSource source)
    {
        // BGM名と一致するサウンドを検索
        SoundObject soundObject = bgmList.Find(s => s.name == bgmName);

        // BGMを再生
        if (soundObject != null)
        {
            soundObject.Play(source);
        }
        else
        {
            Debug.LogWarning("BGM not found: " + bgmName);
        }
    }

    // SEを再生する関数
    public void PlaySE(string seName, AudioSource source)
    {
        // SE名と一致するサウンドを検索
        SoundObject soundObject = seList.Find(s => s.name == seName);

        // SEを再生
        if (soundObject != null)
        {
            soundObject.Play(source);
        }
        else
        {
            Debug.LogWarning("SE not found: " + seName);
        }
    }
}
