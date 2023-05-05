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
        E_SE_KIND_KEYMOVE,      //  4 "タイトル、オプション画面、ステージ選択でのキー入力の際に再生する。"
        E_SE_KIND_KETTEI,       //  5 "タイトル、オプション画面、ステージ選択での操作の決定をする際に再生。"
        E_SE_KIND_CANCEL,       //  6 "タイトル、オプション画面、ステージ選択での操作を戻るをする際に再生。"
        E_SE_KIND_BEEP,         //  7 "タイトル、オプション画面、ステージ選択での操作を決定した際に選択不可の区画、階層を選択していた場合再生。"
        E_SE_KIND_GAMESTART,    //  8 "タイトル画面ではじめから、続きからを選択した状態で決定ボタン押したあと再生。"
        E_SE_KIND_ASSEMBLE,     //  9 "ガラクタをコアの面に組み立てた時の効果音。"
        E_SE_KIND_PREV_KEYMOVE, // 10 "プレビュー画面で決定後、面を選択する際のキー移動時に再生する。"
        E_SE_KIND_NOISE,        // 11 "組み立て画面。ガラクタにカーソルを合わせた際に出るプレビュー画面の砂嵐と同時に再生。"
        E_SE_KIND_MONITORON,    // 12 "組み立て画面。ガラクタにカーソルを合わせた際に出るプレビュー画面の砂嵐表示後、ガラクタのプレビューを表示する際に再生。"
        E_SE_KIND_MONITOROFF,   // 13 "組み立て画面。ガラクタにカーソルを合わせた際に出るプレビュー画面の砂嵐表示後、ガラクタのプレビューを表示する際に再生。"
        E_SE_KIND_OPTION,       // 14 "メニューを開く関連したボタンを押すと再生される。タイトルでのオプションを押しても再生"
        E_SE_KIND_WIND,         // 15 "ステージ内オブジェクトの送風機から発生する風の効果音。送風機がある場合は再生し続ける"
        E_SE_KIND_FIRE,         // 16 "ステージ内オブジェクトの燃えているドラム缶の炎の効果音。"
        E_SE_KIND_HARETU,       // 17 "スプリングガラクタのタイヤが釘コンクリートに接触すると破裂し、その際再生されるＳＥ"
        E_SE_KIND_EXPLOTION,    // 18 "特殊ガラクタのドラム缶がダメージオブジェクトの燃えているドラム缶に触れると爆発し、その際に再生"
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