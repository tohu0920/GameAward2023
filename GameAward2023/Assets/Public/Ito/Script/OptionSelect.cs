using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionSelect : MonoBehaviour
{
    //Sceneオブジェクトの取得
    [SerializeReference] GameObject GameScreen;
    [SerializeReference] GameObject OptionScreen;
    [SerializeReference] GameObject kari;
    [SerializeReference] AudioMixerSnapshot BGM;
    
    //変数宣言
    private GameObject BGMImage1;
    private GameObject BGMImage2;    
    private GameObject SEImage1;
    private GameObject SEImage2;    
    private GameObject ReadMeImage1;
    private GameObject ReadMeImage2;            

    public Slider bgmSlider;         // Sliderを格納する変数
    public Slider SESlider;          // SEを格納する変数
    public AudioSource BGMSource;    // BGMを再生するAudioSourceを格納する変数
    public AudioSource SESourse;     // SE再生するAudioSourceを格納する変数

    public int SelectOptionNum; //UI選択用

    // Start is called before the first frame update
    void Start()
    {
        //Imageの取得
        BGMImage1 = GameObject.Find("BGMImage1");       //光っている
        BGMImage2 = GameObject.Find("BGMImage2");       //光っていない
        SEImage1 = GameObject.Find("SEImage1");         //光っていない
        SEImage2 = GameObject.Find("SEImage2");         //光っている
        ReadMeImage1 = GameObject.Find("ReadMeImage1"); //光っていない
        ReadMeImage2 = GameObject.Find("ReadMeImage2"); //光っている

        //BGM・SEの初期音量設定
        bgmSlider.value = 5.0f;
        SESlider.value = 5.0f;

        //選択用変数の初期化
        SelectOptionNum = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        //選択変更処理
        SelectOptionNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX");

        //選択のループ
        SelectOptionNum += 3;
        SelectOptionNum %= 3;
        
        switch (SelectOptionNum)
        {
            case 0:
                //音量がひかっている
                ChangeActive();

                bgmSlider.value += AxisInput.GetAxisRawRepeat("Horizontal_PadX") * 5.0f;
                break;

            case 1:
                //効果音が光っている
                ChangeActive();

                SESlider.value += AxisInput.GetAxisRawRepeat("Horizontal_PadX") * 5.0f;
                break;

            case 2:
                //操作説明が光っている
                ChangeActive();

                //if (PadInput.GetKeyDown(KeyCode.JoystickButton0))

                break;
        }        

        if (PadInput.GetKeyDown(KeyCode.JoystickButton1))
        {
            GameScreen.SetActive(true);
            OptionScreen.SetActive(false);
            kari.SetActive(true);
        }
    }

    /// <summary>
    /// BGMの音量の設定関数
    /// </summary>
    /// <param name="volume"></param>
    public void SetBGM(float volume)
    {
        BGM.audioMixer.SetFloat("BGM", volume);
        Debug.Log(volume);
    }

    /// <summary>
    /// SEの音量設定
    /// </summary>
    /// <param name="volume"></param>
    public void SetSE(float volume)
    {
        BGM.audioMixer.SetFloat("SE", volume);
    }

    /// <summary>
    /// /// イメージアクティブ・非アクティブ変更関数
    /// </summary>
    public void ChangeActive()
    {
        switch(SelectOptionNum)
        {
            case 0:
                BGMImage1.SetActive(true);
                BGMImage2.SetActive(false);
                SEImage1.SetActive(true);
                SEImage2.SetActive(false);
                ReadMeImage1.SetActive(true);
                ReadMeImage2.SetActive(false);
                break;

            case 1:
                BGMImage1.SetActive(false);
                BGMImage2.SetActive(true);
                SEImage1.SetActive(false);
                SEImage2.SetActive(true);
                ReadMeImage1.SetActive(true);
                ReadMeImage2.SetActive(false);
                break;

            case 2:
                BGMImage1.SetActive(false);
                BGMImage2.SetActive(true);
                SEImage1.SetActive(true);
                SEImage2.SetActive(false);
                ReadMeImage1.SetActive(false);
                ReadMeImage2.SetActive(true);
                break;
        }
    }
}
