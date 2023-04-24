using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionSelect : MonoBehaviour
{
    //Sceneオブジェクトの取得
    [SerializeReference] GameObject TitleScreen;
    [SerializeReference] GameObject OptionsScreen;
    [SerializeReference] GameObject ControleObject;
    [SerializeReference] AudioMixerSnapshot BGMResource;
    
    //変数宣言
    private GameObject LightBGMImage;
    private GameObject BGMImage;    
    private GameObject SEImage;
    private GameObject LightSEImage;    
    private GameObject ReadMeImage;
    private GameObject LightReadMeImage;            

    public Slider bgmVolumeSlider;         // Sliderを格納する変数
    public Slider SEVolumeSlider;          // SEを格納する変数
    public AudioSource BGMSource_camera;    // BGMを再生するAudioSourceを格納する変数
    public AudioSource SESourse_camera;     // SE再生するAudioSourceを格納する変数

    public int OptionNum; //UI選択用

    // Start is called before the first frame update
    void Start()
    {
        //Imageの取得
        LightBGMImage = GameObject.Find("BGMImage1");       //光っている
        BGMImage      = GameObject.Find("BGMImage2");       //光っていない
        SEImage       = GameObject.Find("SEImage1");         //光っていない
        LightSEImage  = GameObject.Find("SEImage2");         //光っている
        ReadMeImage   = GameObject.Find("ReadMeImage1"); //光っていない
        LightReadMeImage = GameObject.Find("ReadMeImage2"); //光っている

        //BGM・SEの初期音量設定
        bgmVolumeSlider.value = 5.0f;
        SEVolumeSlider.value  = 5.0f;

        //選択用変数の初期化
        OptionNum = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        //選択変更処理
        OptionNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX");

        //選択のループ
        OptionNum += 3;
        OptionNum %= 3;
        
        switch (OptionNum)
        {
            case 0:
                //音量がひかっている
                ChangeImageActive();

                bgmVolumeSlider.value += AxisInput.GetAxisRawRepeat("Horizontal_PadX") * 5.0f;
                break;

            case 1:
                //効果音が光っている
                ChangeImageActive();

                SEVolumeSlider.value += AxisInput.GetAxisRawRepeat("Horizontal_PadX") * 5.0f;
                break;

            case 2:
                //操作説明が光っている
                ChangeImageActive();

                //if (PadInput.GetKeyDown(KeyCode.JoystickButton0))

                break;
        }        

        if (PadInput.GetKeyDown(KeyCode.JoystickButton1))
        {
            TitleScreen.SetActive(true);
            OptionsScreen.SetActive(false);
            ControleObject.SetActive(true);
        }
    }

    /// <summary>
    /// BGMの音量の設定関数
    /// </summary>
    /// <param name="volume"></param>
    public void SetBGM(float volume)
    {
        BGMResource.audioMixer.SetFloat("BGM", volume);
        Debug.Log(volume);
    }

    /// <summary>
    /// SEの音量設定
    /// </summary>
    /// <param name="volume"></param>
    public void SetSE(float volume)
    {
        BGMResource.audioMixer.SetFloat("SE", volume);
    }

    /// <summary>
    /// /// イメージアクティブ・非アクティブ変更関数
    /// </summary>
    public void ChangeImageActive()
    {
        switch(OptionNum)
        {
            case 0:
                LightBGMImage.SetActive(true);
                BGMImage.SetActive(false);
                SEImage.SetActive(true);
                LightSEImage.SetActive(false);
                ReadMeImage.SetActive(true);
                LightReadMeImage.SetActive(false);
                break;

            case 1:
                LightBGMImage.SetActive(false);
                BGMImage.SetActive(true);
                SEImage.SetActive(false);
                LightSEImage.SetActive(true);
                ReadMeImage.SetActive(true);
                LightReadMeImage.SetActive(false);
                break;

            case 2:
                LightBGMImage.SetActive(false);
                BGMImage.SetActive(true);
                SEImage.SetActive(true);
                LightSEImage.SetActive(false);
                ReadMeImage.SetActive(false);
                LightReadMeImage.SetActive(true);
                break;
        }
    }
}
